<cfscript>
	cfcPlacard = CreateObject('component', 'Placard');

	if (URL.action EQ "update"){
		jItems = cfcPlacard.getLocation(URL.locInput);
		writeOutput(jItems);}
	else if (URL.action EQ "setdataAddress1"){
		jLocAddress1 = cfcPlacard.getLocationData(URL.locInput, 'address1');
		writeOutput(jLocAddress1);}
	else if (URL.action EQ "setdataAddress2"){
		jLocAddress2 = cfcPlacard.getLocationData(URL.locInput, 'address2');
		writeOutput(jLocAddress2);}
	else if (URL.action EQ "setdataCity"){
		jLocCity = cfcPlacard.getLocationData(URL.locInput, 'city');
		writeOutput(jLocCity);}
	else if (URL.action EQ "setdataState"){
		jLocState = cfcPlacard.getLocationData(URL.locInput, 'state');
		writeOutput(jLocState);}
	else if (URL.action EQ "setdataZip"){
		jLocZip = cfcPlacard.getLocationData(URL.locInput, 'zip');
		writeOutput(jLocZip);}
	else if (URL.action EQ "setdataPhone"){
		jLocPhone = cfcPlacard.getLocationData(URL.locInput, 'telephone');
		writeOutput(jLocPhone);}


	/* THIS LOGIC IS FOR THE SECOND REQUEST WITH THE DROP DOWN */

	else if (URL.action EQ "setdataSecRqstAddress1"){
		jLocAddress1 = cfcPlacard.getLocationData(URL.locInput, 'address1');
		writeOutput(jLocAddress1);}
	else if (URL.action EQ "setdataSecRqstAddress2"){
		jLocAddress2 = cfcPlacard.getLocationData(URL.locInput, 'address2');
		writeOutput(jLocAddress2);}
	else if (URL.action EQ "setdataSecRqstCity"){
		jLocCity = cfcPlacard.getLocationData(URL.locInput, 'city');
		writeOutput(jLocCity);}
	else if (URL.action EQ "setdataSecRqstState"){
		jLocState = cfcPlacard.getLocationData(URL.locInput, 'state');
		writeOutput(jLocState);}
	else if (URL.action EQ "setdataSecRqstZip"){
		jLocZip = cfcPlacard.getLocationData(URL.locInput, 'zip');
		writeOutput(jLocZip);}
	else if (URL.action EQ "setdataSecRqstTel"){
		jLocTel = cfcPlacard.getLocationData(URL.locInput, 'telephone');
		writeOutput(jLocTel);}


	/* END OF NEW CODE */
	else if (URL.action EQ "consUpdate"){
		jConsignees = cfcPlacard.getConsignees(URL.locInput);
		writeOutput(jConsignees);}
	else if (URL.action EQ "setConsAttnTo"){
		jConsAttnTo = cfcPlacard.getPlacardData(URL.locInput, 'attentionTo');
		writeOutput(jConsAttnTo);}
	else if (URL.action EQ "setConsAddress1"){
		jConsAddress1 = cfcPlacard.getPlacardData(URL.locInput, 'address1');
		writeOutput(jConsAddress1);}
	else if (URL.action EQ "setConsAddress2"){
		jConsAddress2 = cfcPlacard.getPlacardData(URL.locInput, 'address2');
		writeOutput(jConsAddress2);}
	else if (URL.action EQ "setConsCity"){
		jConsCity = cfcPlacard.getPlacardData(URL.locInput, 'city');
		writeOutput(jConsCity);}
	else if (URL.action EQ "setConsState"){
		jConsState = cfcPlacard.getPlacardData(URL.locInput, 'state');
		writeOutput(jConsState);}
	else if (URL.action EQ "setConsZip"){
		jConsZip = cfcPlacard.getPlacardData(URL.locInput, 'zip');
		writeOutput(jConsZip);}
	else if (URL.action EQ "setConsPhone"){
		jConsPhone = cfcPlacard.getPlacardData(URL.locInput, 'telephone');
		writeOutput(jConsPhone);}

</cfscript>