<cfscript>
	param name="thePage" default="";
	param name="title" default="Placard Manager";
	param name="titleLink" default="/";
</cfscript>

<!DOCTYPE HTML>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

    <title>Placard Manager</title>

	<!---CSS--->
	<link href="css/aqueous.css" rel="stylesheet" type="text/css" />
	<link href="css/default.css" rel="stylesheet" type="text/css" />
	<link href="plugins/jQueryUI/1.10.4/css/smoothness/jquery-ui-1.10.4.custom.css" rel="stylesheet"  type="text/css" />
	<link href="plugins/DataTables-1.9.4/extras/TableTools/media/css/TableTools.css" rel="stylesheet" type="text/css" />
	<link href="plugins/select2/css/select2.css" rel="stylesheet" type="text/css" />
	<link href="include/style.css" rel="stylesheet" type="text/css" />

	<!---JS--->
	<script src="plugins/jQuery/jquery-1.10.2.js" type="text/javascript" language="javascript" ></script>
	<script src="plugins/jQueryUI/1.10.4/js/jquery-ui-1.10.4.custom.js"  type="text/javascript" language="javascript" ></script>
	<script src="plugins/select2/select2.min.js" type="text/javascript" language="javascript" ></script>
</head>
<body>

<cfinclude template="controller.cfm" />

<cfoutput>
<div id="wrapper" style="margin-right: 0 auto; max-width:1060px; min-width:1060px;">
	<div id="innerwrapper">
		<div id="header">
			<h1><a href="#titleLink#">#title#</a></h1>
	      	<h2>ColdFusion Exam</h2>
		</div>

		<cfinclude template="action.cfm" />

		<cfinclude template="form.cfm" />

		<cfinclude template="history.cfm" />

	</div> <!--- id="innerwrapper" --->
 </div> <!--- id="wrapper" --->
</cfoutput>

<!---JS in the bottom--->
<script src="plugins/DataTables-1.9.4/media/js/jquery.dataTables.min.js" type="text/javascript" language="javascript" ></script>
<script src="plugins/DataTables-1.9.4/extras/FixedHeader/js/FixedHeader.js" type="text/javascript" language="javascript" ></script>
<script src="plugins/DataTables-1.9.4/extras/TableTools/media/js/TableTools.js" type="text/javascript" language="javascript" ></script>
<script src="plugins/DataTables-1.9.4/extras/TableTools/media/js/ZeroClipboard.js" type="text/javascript" language="javascript" ></script>
<script src="include/script.js" type="text/javascript" language="JavaScript" ></script>
</body>