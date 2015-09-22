<?php
session_start();
?>
<!DOCTYPE html>
<html>
<head>
	<title>HTMLTagsCounter</title>
	<link rel="stylesheet" href="styles/HTMLTagsCounter.css"/>
	<meta charset="UTF-8" />
</head>
<body>
	<form method="get">
		<label>Enter HTML Tags:</label>
		<input type="text" name="tag" id="tag"/>
		<button>Submit</button>
	</form>
	<script src="scripts/HTMLTagsCounter.js"></script>
	<?php
	if(!isset($_SESSION['count']))
			$_SESSION['count'] = 0;
	if(isset($_GET['tag'])) {	
		if($_GET['tag'] == '!DOCTYPE' || $_GET['tag'] == 'a' || $_GET['tag'] == 'abbr' || $_GET['tag'] == 'acronym'
			|| $_GET['tag'] == 'address' || $_GET['tag'] == 'applet' || $_GET['tag'] == 'area' || $_GET['tag'] == 'article'
			|| $_GET['tag'] == 'aside' || $_GET['tag'] == 'audio' || $_GET['tag'] == 'b' || $_GET['tag'] == 'base' 
			|| $_GET['tag'] == 'basefont' || $_GET['tag'] == 'bdi' || $_GET['tag'] == 'bdo' || $_GET['tag'] == 'big'
			|| $_GET['tag'] == 'blockquote' || $_GET['tag'] == 'body' || $_GET['tag'] == 'br' || $_GET['tag'] == 'button'
			|| $_GET['tag'] == 'canvas' || $_GET['tag'] == 'caption' || $_GET['tag'] == 'center' || $_GET['tag'] == 'cite'
			|| $_GET['tag'] == 'code' || $_GET['tag'] == 'col' || $_GET['tag'] == 'colgroup' || $_GET['tag'] == 'command'
			|| $_GET['tag'] == 'datalist' || $_GET['tag'] == 'dd' || $_GET['tag'] == 'del' || $_GET['tag'] == 'details'
			|| $_GET['tag'] == 'dfn' || $_GET['tag'] == 'dir' || $_GET['tag'] == 'div' || $_GET['tag'] == 'dl'
			|| $_GET['tag'] == 'dt' || $_GET['tag'] == 'em' || $_GET['tag'] == 'embed' || $_GET['tag'] == 'fieldset'
			|| $_GET['tag'] == 'figcaption' || $_GET['tag'] == 'figure' || $_GET['tag'] == 'font' || $_GET['tag'] == 'footer'
			|| $_GET['tag'] == 'form' || $_GET['tag'] == 'frame' || $_GET['tag'] == 'frameset' || $_GET['tag'] == 'h1'
			|| $_GET['tag'] == 'h2' || $_GET['tag'] == 'h3' || $_GET['tag'] == 'h4' || $_GET['tag'] == 'h5' || $_GET['tag'] == 'h6'
			|| $_GET['tag'] == 'head' || $_GET['tag'] == 'header' || $_GET['tag'] == 'hgroup' || $_GET['tag'] == 'hr'
			|| $_GET['tag'] == 'html' || $_GET['tag'] == 'i' || $_GET['tag'] == 'iframe' || $_GET['tag'] == 'img'
			|| $_GET['tag'] == 'input' || $_GET['tag'] == 'ins' || $_GET['tag'] == 'kbd' || $_GET['tag'] == 'keygen' 
			|| $_GET['tag'] == 'label' || $_GET['tag'] == 'legend'
			|| $_GET['tag'] == 'li' || $_GET['tag'] == 'link' || $_GET['tag'] == 'map' || $_GET['tag'] == 'mark'
			|| $_GET['tag'] == 'menu' || $_GET['tag'] == 'meta' || $_GET['tag'] == 'meter' || $_GET['tag'] == 'nav' 
			|| $_GET['tag'] == 'noframes' || $_GET['tag'] == 'noscript' || $_GET['tag'] == 'object' || $_GET['tag'] == 'ol'
			|| $_GET['tag'] == 'optgroup' || $_GET['tag'] == 'option' || $_GET['tag'] == 'output' || $_GET['tag'] == 'p'
			|| $_GET['tag'] == 'param' || $_GET['tag'] == 'pre' || $_GET['tag'] == 'progress' || $_GET['tag'] == 'q'
			|| $_GET['tag'] == 'rp' || $_GET['tag'] == 'rt' || $_GET['tag'] == 'ruby' || $_GET['tag'] == 's'
			|| $_GET['tag'] == 'samp' || $_GET['tag'] == 'script' || $_GET['tag'] == 'section' || $_GET['tag'] == 'select'
			|| $_GET['tag'] == 'small' || $_GET['tag'] == 'source' || $_GET['tag'] == 'span' || $_GET['tag'] == 'strike'
			|| $_GET['tag'] == 'strong' || $_GET['tag'] == 'style' || $_GET['tag'] == 'sub' || $_GET['tag'] == 'summary'
			|| $_GET['tag'] == 'sup' || $_GET['tag'] == 'table' || $_GET['tag'] == 'tbody' || $_GET['tag'] == 'td'
			|| $_GET['tag'] == 'textarea' || $_GET['tag'] == 'tfoot' || $_GET['tag'] == 'th' || $_GET['tag'] == 'thead'
			|| $_GET['tag'] == 'time' || $_GET['tag'] == 'title' || $_GET['tag'] == 'tr' || $_GET['tag'] == 'track' || $_GET['tag'] == 'tt'
			|| $_GET['tag'] == 'u' || $_GET['tag'] == 'ul' || $_GET['tag'] == 'var' || $_GET['tag'] == 'video'
			|| $_GET['tag'] == 'wbr') {
			echo 'Valid HTML tag!<br>';
			$_SESSION['count']++;
			echo 'Score: ' . $_SESSION['count']; 
		}
		else {
			echo 'Invalid HTML tag!<br>';
			echo 'Score: ' . $_SESSION['count'];
		}    
	}
	?>
</body>
</html>
