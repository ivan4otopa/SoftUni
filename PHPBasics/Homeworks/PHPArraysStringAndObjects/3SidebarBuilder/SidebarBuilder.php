<!DOCTYPE html>
<html>
	<head>
		<title>SidebarBuilder</title>
		<link rel="stylesheet" href="styles/SidebarBuilder.css" />
	</head>
	<body>
		<form method="get">
			<label>Categories:</label>
			<input type="text" name="categories" /><br />
			<label>Tags:</label>
			<input type="text" name="tags" /><br />
			<label>Months:</label>
			<input type="text" name="months" /><br />
			<button>Generate</button>
		</form>
		<?php
		if(isset($_GET['categories'], $_GET['tags'], $_GET['months'])):
			$categories = $_GET['categories'];
			$tags = $_GET['tags'];
			$months = $_GET['months'];
			$categoriesArray = explode(', ', $categories);
			$tagsArray = explode(', ', $tags);
			$monthsArray = explode(', ', $months);
		?>
		<aside>
			<h1>Categories</h1>
			<hr>
			<ul>
				<?php foreach ($categoriesArray as $value): ?>
				<li><?= $value ?></li>
				<?php endforeach; ?>
			</ul>
		</aside>
		<aside>
			<h1>Tags</h1>
			<hr>
			<ul>
				<?php foreach ($tagsArray as $value): ?>
				<li><?= $value ?></li>
				<?php endforeach; ?>
			</ul>
		</aside>
		<aside>
			<h1>Months</h1>
			<hr>
			<ul>
				<?php foreach ($monthsArray as $value): ?>
				<li><?= $value ?></li>
				<?php endforeach; ?>
			</ul>
		</aside>
		<?php endif; ?>
	</body>
</html>