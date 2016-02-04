<cfscript>
	param name="URL.placardID" default="0";

	param name = "FORM.fromCompany" 	default = "";
	param name = "FORM.fromAddress1" 	default = "";
	param name = "FORM.fromAddress2" 	default = "";
	param name = "FORM.fromCity" 		default = "";
	param name = "FORM.fromState" 		default = "";
	param name = "FORM.fromZip" 		default = "";
	param name = "FORM.fromTelephone" 	default = "";
	param name = "FORM.toCompany" 		default = "";
	param name = "FORM.toAttentionTo" 	default = "";
	param name = "FORM.toAddress1" 		default = "";
	param name = "FORM.toAddress2" 		default = "";
	param name = "FORM.toCity" 			default = "";
	param name = "FORM.toState" 		default = "";
	param name = "FORM.toZip" 			default = "";
	param name = "FORM.toCountry" 		default = "United States";
	param name = "FORM.toTelephone" 	default = "";
	param name = "FORM.trackingNumber" 	default = "";
	param name = "FORM.PO" 				default = "";
	param name = "FORM.pallets" 		default = "1";
	param name = "FORM.carrier"			default = "";

	cfcPlacard = createobject("component","Placard");
	qLocations = cfcPlacard.getLocations(type=1);
	qCarriers = cfcPlacard.getCarriers();

	if(URL.placardID NEQ "0"){
		qPlacard = cfcPlacard.getPlacard(URL.placardID);

		FORM.fromCompany = qPlacard["plac_fromCompany"];
		FORM.fromAddress1 = qPlacard["plac_fromAddress1"];
		FORM.fromAddress2 = qPlacard["plac_fromAddress2"];
		FORM.fromCity = qPlacard["plac_fromCity"];
		FORM.fromState = qPlacard["plac_fromState"];
		FORM.fromZip = qPlacard["plac_fromZip"];
		FORM.fromTelephone = qPlacard["plac_fromTelephone"];

		FORM.toCompany = qPlacard["plac_toCompany"];
		FORM.toAttentionTo = qPlacard["plac_toAttentionTo"];
		FORM.toAddress1 = qPlacard["plac_toAddress1"];
		FORM.toAddress2 = qPlacard["plac_toAddress2"];
		FORM.toCity = qPlacard["plac_toCity"];
		FORM.toState = qPlacard["plac_toState"];
		FORM.toZip = qPlacard["plac_toZip"];
		FORM.toCountry = qPlacard["plac_toCountry"];
		FORM.toTelephone = qPlacard["plac_toTelephone"];
		FORM.toCountry = qPlacard["plac_toCountry"];
	}
</cfscript>