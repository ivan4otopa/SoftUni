<form action="" method="POST">
	<input type="text" name="name" placeholder="...Name" />
	<input type="submit" value="Start Game" />
</form>
	 
<?php
	if (isset($_POST['name'])) {
		$name = $_POST['name'];
		$randomNumber = mt_rand(1, 100);
		
		setcookie('name', $name);
				
		$_COOKIE['name'] = $name;
		
		setcookie('randomNumber', $randomNumber);
		
		$_COOKIE['randomNumber'] = $randomNumber;
		
		header('Location: play.php');
	}
?>