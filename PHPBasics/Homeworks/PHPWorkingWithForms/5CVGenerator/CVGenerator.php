<!DOCTYPE html>
<html>
	<head>
		<title>CVGenerator</title>
		<link rel="stylesheet" href="styles/CVGenerator.css" />
		<script src="scripts/CVGenerator.js"></script>
	</head>
	<body>
		<form method="get">
			<fieldset>
				<legend>
					Personal Information
				</legend>
				<input type="text" name="fname" placeholder="First Name" />
				<br />
				<input type="text" name="lname" placeholder="Last Name" />
				<br />
				<input type="text" name="email" placeholder="Email" />
				<br />
				<input type="tel" name="phone" placeholder="Phone Number" />
				<br />
				<label for="female">Female</label>
				<input type="radio" name="gender" id="female" value="Female"/>
				<label for="male">Male</label>
				<input type="radio" name="gender" id="male" value="Male"/>
				<br />
				<label>Birthday</label>
				<br />
				<input type="date" name="bday" />
				<br />
				<label>Nationality</label>
				<br />
				<select name="nat">
					<option>Bulgarian</option>
					<option>Indian</option>
				</select>
			</fieldset>
			<fieldset>
				<legend>
					Last Work Position
				</legend>
				<label>Company Name</label>
				<input type="text" name="company" />
				<br />
				<label>From</label>
				<input type="date" name="from" />
				<br />
				<label>To</label>
				<input type="date" name="to" />
				<br />
			</fieldset>
			<fieldset id="compskills">
				<legend>
					Computer Skills
				</legend>
				<label>Programming Languages</label>
				<br />
				<div class="clone">
					<input type="text" name="proglang[]"/>
					<select name="progrlang[]">
						<option>Beginner</option>
						<option>Programmer</option>
						<option>Ninja</option>
					</select><br />
				</div>
				<button type="button" onclick="removeProgLanguage()" id="remove">
					Remove Language
				</button>
				<button type="button" onclick="addProgLanguage()">
					Add Language
				</button>
			</fieldset>
			<fieldset id="otherskills">
				<legend>
					Other Skills
				</legend>
				<label>Languages</label>
				<br />
				<div class="clone2">
					<input type="text" name="lang[]" />
					<select name="compr[]">
						<option disabled="disabled" selected="selected">-Comprehension-</option>
						<option>intermediate</option>
						<option>advanced</option>
					</select>
					<select name="read[]">
						<option disabled="disabled" selected="selected">-Reading-</option>
						<option>beginner</option>
					</select>
					<select name="write[]">
						<option disabled="disabled" selected="selected">-Writing-</option>
						<option>intermediate</option>
						<option>advanced</option>
					</select>
				</div>
				<button type="button" onclick="removeLanguage()" id="remove2">
					Remove Language
				</button>
				<button type="button" onclick="addLanguage()">
					Add Language
				</button>
				<br />
				<label>Driver`s License</>
					<br />
					<label for="b">B</label>
					<input type="checkbox" name="b" />
					<label for="a">A</label>
					<input type="checkbox" name="a" />
					<label for="c">C</label>
					<input type="checkbox" name="c" />
			</fieldset>
			<button>
				Generate CV
			</button>
		</form>
		<?php
		if (isset($_GET['fname'], $_GET['lname'], $_GET['email'], $_GET['phone'], $_GET['gender'], $_GET['bday'],
			$_GET['nat'], $_GET['company'], $_GET['from'], $_GET['to'], $_GET['proglang'], $_GET['progrlang'],
			$_GET['lang'], $_GET['compr'], $_GET['read'], $_GET['write'])):
			$fname = $_GET['fname'];
			$lname = $_GET['lname'];
			$email = $_GET['email'];
			$phone = $_GET['phone'];
			$gender = $_GET['gender'];
			$bday = $_GET['bday'];
			$nat = $_GET['nat'];
			$company = $_GET['company'];
			$from = $_GET['from'];
			$to = $_GET['to'];
			$proglangs = $_GET['proglang'];
			$progrlangs = $_GET['progrlang'];
			$langs = $_GET['lang'];
			$comprs = $_GET['compr'];
			$reads = $_GET['read'];
			$writes = $_GET['write'];
			$driverLicenses = array();
			if(isset($_GET['b']))
				array_push($driverLicenses, 'B');
			if(isset($_GET['a']))
				array_push($driverLicenses, 'A');
			if(isset($_GET['c']))
				array_push($driverLicenses, 'C');
			$driverLicenses = implode(', ', $driverLicenses);
			if(!preg_match('/[a-zA-Z]/', $fname) || !preg_match('/[a-zA-Z]/', $lname) || strlen($fname) < 3 || strlen($fname) > 19
				|| strlen($lname) < 3 || strlen($lname) > 19)
				die('First Name, Last Name need to be only latin letters and between 2 and 20 symbols');	
			foreach ($langs as $key => $value) {
				if(!preg_match('/[a-zA-Z]/', $value) || strlen($value) < 3 || strlen($value) > 19)
					die('Languages must consist only of latin letters and length between 2 and 20 symbols');
			}
			if(!preg_match('/[0-9a-zA-Z]+/', $company) || strlen($company) < 3 || strlen($company) > 19)
				die('Company Name must consist of numbers and latin letters and length between 2 and 20 symbols');
			if(!preg_match('/[0-9-\+ ]+/', $phone))
				die('Phone number must consist of numbers, +, - and whitespaces');
			if(!preg_match('/[0-9a-zA-Z]+[@][0-9a-zA-Z]+[\.][0-9a-zA-Z]+/', $email))
				die('Valid Email consists of latin letters, numbers, one @, and one .');
		?>
		<table>
			<thead>
				<tr>
					<th colspan="2">Personal Information</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>First Name</td>
					<td><?= $fname; ?></td>
				</tr>
				<tr>
					<td>Last Name</td>
					<td><?= $lname; ?></td>
				</tr>
				<tr>
					<td>Email</td>
					<td><?= $email; ?></td>
				</tr>
				<tr>
					<td>Phone Number</td>
					<td><?= $phone; ?></td>
				</tr>
				<tr>
					<td>Gender</td>
					<td><?= $gender; ?></td>
				</tr>
				<tr>
					<td>Birth Date</td>
					<td><?= $bday; ?></td>
				</tr>
				<tr>
					<td>Nationality</td>
					<td><?= $nat; ?></td>
				</tr>
			</tbody>
		</table>
		<table>
			<thead>
				<tr>
					<th colspan="2">Last work position</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Company Name</td>
					<td><?= $company; ?></td>
				</tr>
				<tr>
					<td>From</td>
					<td><?= $from; ?></td>
				</tr>
				<tr>
					<td>To</td>
					<td><?= $to; ?></td>
			</tbody>
		</table>
		<table>
			<thead>
				<tr>
					<th colspan="2">Computer Skills</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Programing Languages</td>
					<td>
						<table>
							<thead>
								<tr>
									<th>Language</th>
									<th>Skill Level</th>
								</tr>
							</thead>
							<tbody>
								<?php for($i = 0; $i < count($proglangs); $i++): ?>
								<tr>
									<td><?= $proglangs[$i] ?></td>
									<td><?= $progrlangs[$i] ?></td>
								</tr>
								<?php endfor; ?>
							</tbody>
						</table>
					</td>
				</tr>
			</tbody>
		</table>
		<table>
			<thead>
				<tr>
					<th colspan="2">Other Skills</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Languages</td>
					<td>
						<table>
							<thead>
								<tr>
									<th>Language</th>
									<th>Comprehension</th>
									<th>Reading</th>
									<th>Writing</th>
								</tr>
							</thead>
							<tbody>
								<?php for($i = 0; $i < count($langs); $i++): ?>
								<tr>
									<td><?= $langs[$i] ?></td>
									<td><?= $comprs[$i] ?></td>
									<td><?= $reads[$i] ?></td>
									<td><?= $writes[$i] ?></td>
								</tr>
								<?php endfor; ?>
								
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td>Driver's License</td>
					<td><?= $driverLicenses ?></td>
				</tr> 
			</tbody>
		</table>
		<?php endif; ?>
	</body>
</html>