var images = ['http://kimjoyfox.com/blog/wp-content/uploads/drwho8.jpg', 'http://kimjoyfox.com/blog/wp-content/uploads/drwho7.jpg', 'http://kimjoyfox.com/blog/wp-content/uploads/drwho6.jpg', 'http://kimjoyfox.com/blog/wp-content/uploads/drwho5.jpg', 'http://kimjoyfox.com/blog/wp-content/uploads/drwho4.jpg', 'http://kimjoyfox.com/blog/wp-content/uploads/drwho3.jpg'];

$(document).ready(function() {

    beginNow = setInterval(forwardImage, 5000);

    $('#leftArrow').click(function() {
        clearInterval(beginNow);
        backwardsImage();
    });

    $('#rightArrow').click(function() {
        clearInterval(beginNow);
        forwardImage();
    });

    function currentImageKey() {
        i = jQuery.inArray($('#slideshow').attr('src'), images);
        return i;
    }

    function backwardsImage() {
        currentImageKey();
        if (i == 0) {
            //changeImage(images.length - 1);
        } else {
            changeImage(i - 1);
        }
        checkArrows(i - 1);
    }

    function forwardImage() {
        currentImageKey();
        if (i < images.length - 1) {
            changeImage(i + 1);
        } else {
            //changeImage(0);
        }
        checkArrows(i+1) ;
    }

    function checkArrows(i) {
        if (i == 0) {
            $('#leftArrow').css('display', 'none');
            $('#rightArrow').css('display', 'inline');
        } else if (i == images.length - 1) {
            $('#rightArrow').css('display', 'none');
            $('#leftArrow').css('display', 'inline');
        } else {
            $('#rightArrow').css('display', 'inline');
            $('#leftArrow').css('display', 'inline');
        }
    }

    function changeImage(i) {
        $('#slideshow').stop().animate({
            opacity: 0,
        }, 200, function() {
            $('#slideshow').attr('src', images[i]);
            $('#holder img').load(function() {
                $('#slideshow').stop().animate({
                    opacity: 1,
                }, 200)
            })
        })
    }
});