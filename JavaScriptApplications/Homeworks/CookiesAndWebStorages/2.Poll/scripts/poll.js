var interval,
	buttonSubmit = $('button');

function startTimer(duration, display) {
    var timer = duration, minutes, seconds;
    interval = setInterval(function () {
        minutes = parseInt(timer / 60, 10)
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + ":" + seconds);

        if (--timer < 0) {
            timer = duration;
        }
    }, 1000);
}

jQuery(function ($) {
    var fiveMinutes = 60 * 5,
        display = $('#time');
    startTimer(fiveMinutes, display);
});

$(function()
{
    $('input[type=radio]').each(function()
    {
        var state = JSON.parse( localStorage.getItem('radio_'  + this.id) );

        if (state) {
        	this.checked = state.checked;
       	}
    });
});

$(window).bind('unload', function()
{
    $('input[type=radio]').each(function()
    {
        localStorage.setItem(
            'radio_' + this.id, JSON.stringify({checked: this.checked})
        );
    });
});

buttonSubmit.on('click', function () {
	clearInterval(interval);
	$('<div></div>').text('Верни отговори:').appendTo('body');
	$('<div></div>').text('1.64').appendTo('body');
	$('<div></div>').text('2.Дама').appendTo('body');
})