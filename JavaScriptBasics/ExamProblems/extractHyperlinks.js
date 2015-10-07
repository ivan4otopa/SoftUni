function extractHyperlinks(input) {
	var html = input.join('');
	var aTags = html.match(/<a[^>]+>/g);
	var links = [];
	for(var link in aTags) {
		var pattern = /href\s*=\s*"[^"]+"|href\s*=\s*'[^']+'/g;
		var match = pattern.exec(aTags[link]);
		console.log(match[0]);
	}
}

extractHyperlinks(['<html>',
    '<head>',
               '<title>Hyperlinks</title>',
               '<link href="theme.css" rel="stylesheet" />',
           '</head>',
           '<body>',
               '<ul><li><a   href="/"  id="home">Home</a></li><li><a',
               'class="selected" href="/courses">Courses</a>',
               '</li><li><a href =',
               "'/forum' >Forum</a></li><li><a class=\"href\"",
               'onclick="go()" href= "#">Forum</a></li>',
                   '<li><a id="js" href =',
                   '"javascript:alert(\'hi\')" class="new">click</a></li>',
                   '<li><a id=\'nakov\' href =',
                   "'http://www.nakov.com' class='new'>nak</a></li></ul>",
               '<a href="#"></a>',
               "<a id=\"href='jhj'\">href='fake'<img src='http://abv.bg/i.gif'",
               "alt='abv'/></a><a href=\"#\">&lt;a href='hello'&gt;</a>",
               '<!-- This code is commented:',
                 '<a href="#commented">commentex hyperlink</a> -->',
           '</body>']
);