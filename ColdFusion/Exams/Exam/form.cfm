<cfoutput>
	<cfform action = "index.cfm" autocomplete = "off">
		<table width="100%">
			<tr>
				<td><h3>SHIP AS</h3></td>
				<td><h3>SHIP TO</h3></td>
			</tr>
			<tr>
				<td>
					<label for="fromCompany">Company</label>
					<input type="text" name="fromCompany" id="fromCompany" value="#FORM.fromCompany#" tabindex="1" /></td>
				<td>
					<label for="toCompany">Consignee</label>
					<input type="text" name="toCompany" id="toCompany" value="#FORM.toCompany#" tabindex = "12" />
				</td>
			</tr>
			<tr>
				<td>SHIP FROM
					<select name="locationID" id="locationID" tabindex="2" onChange="loadFromAddressOnChange()" data-placeholder="Select location..." style="width:200px;">
						<option></option>
						<cfloop query = "qLocations">
							<option value = "#loc_ID#">#loc_State# - #loc_Name#</option>
						</cfloop>
					</select>
				</td>
				<td>
					<label for="toAttentionTo">Attention</label>
					<input type="text" name="toAttentionTo" id="toAttentionTo" value="#FORM.toAttentionTo#" tabindex = "13" /></td>
				</tr>
			<tr>
				<td>
					<label for="fromAddress1">Street Address</label>
					<input type="text" name="fromAddress1" id="fromAddress1" value="#FORM.fromAddress1#" tabindex = "3" />
				</td>
				<td><label for="toAddress1">Street Address</label>
					<input type="text" name="toAddress1" id="toAddress1" value="#FORM.toAddress1#" tabindex = "14" />
				</td>
			</tr>
			<tr>
			<td>
				<label for="fromAddress2">Floor/Suite/Dock/Bay</label>
				<input type="text" name="fromAddress2" id="fromAddress2" value="#FORM.fromAddress2#" tabindex = "4" />
			</td>
			<td>
				<label for="toAddress2">Floor/Suite/Dock/Bay</label>
				<input type="text" name="toAddress2" id="toAddress2" value="#FORM.toAddress2#" tabindex = "15" />
			</td>
			</tr>
			<tr>
				<td>
					<div>
						<div style="float:left;">
							<label for="fromCity">City</label>
							<input name="fromCity" type="text" id="fromCity" tabindex = "5" value="#FORM.fromCity#" size="30" class="cityInput" />
						</div>
						<div style="float:left;">
							<label for="fromState">State</label>
							<input name="fromState" type="text" id="fromState" tabindex = "6" value="#FORM.fromState#" size="6" maxlength="2" class="stateCityInput" />
						</div>
						<div style="float:left;">
							<label for="fromZip">Zip</label>
							<input name="fromZip" type="text" id="fromZip" tabindex = "7" value="#FORM.fromZip#" size="6" maxlength="5" class="stateCityInput"/>
						</div>
					</div>
				</td>
				<td>
					<div>
						<div style="float:left;">
							<label for="toCity">City</label>
							<input name="toCity" type="text" id="toCity" tabindex = "16" value="#FORM.toCity#" size="30" class="cityInput" />
						</div>
						<div style="float:left;">
							<label for="toState">State</label>
							<input name="toState" type="text" id="toState" tabindex = "17" value="#FORM.toState#" size="6" maxlength="2" class="stateCityInput" />
						</div>
						<div style="float:left;">
							<label for="toZip">Zip</label>
							<input name="toZip" type="text" id="toZip" tabindex = "18" value="#FORM.toZip#" size="6" maxlength="6" class="stateCityInput"/>
						</div>
					</div>
				</td>
			</tr>
			<tr>
				<td>
					<label for="fromTelephone">Telephone</label>
					<cfinput type="text" name="fromTelephone" id="fromTelephone" value="#FORM.fromTelephone#" mask="(999) 999-9999" tabindex = "8" label="Telephone" />
				</td>
				<td>
					<label for="toCountry">Country</label>
					<select name="toCountry" id="toCountry" tabindex = "19">
						<option value="United States" <cfif FORM.toCountry EQ "United States">selected</cfif>>United States</option>
						<option value="Canada" <cfif FORM.toCountry EQ "Canada">selected</cfif>>Canada</option>
					</select>
				</td>
			</tr>
			<tr>
				<td><h3>SHIPMENT INFORMATION</h3></td>
				<td>
					<label for="toTelephone">Telephone</label>
					<cfinput type="text" name="toTelephone" id="toTelephone" value="#FORM.toTelephone#" mask="(999) 999-9999" tabindex = "20"/>
				</td>
			</tr>
			<tr>
				<td>
					<label for="pallets2">Number of Pallets</label>
					<input name="pallets" type="text" id="pallets" tabindex = "9" value="#FORM.pallets#" maxlength="2" />
				</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>
					<label for="po">PO</label>
					<input type="text" name="po" id="po" value="#FORM.PO#" tabindex = "10" />
				</td>
			</tr>
			<tr>
				<td>
					<label for="trackingNumber3">PRO/Tracking Number</label>
					<input type="text" name="trackingNumber" value="#FORM.trackingNumber#" id="trackingNumber3" tabindex = "11" />
				</td>
				<td rowspan="2" valign="bottom">
					<input type="submit" name="saveBtn" id="saveBtn" value="Print" class="customBtn saveBtn"/>
					<input type="button" name="resetBtn" id="resetBtn" value="Reset" class="customBtn2 saveBtn" onClick="location.href='index.cfm?editPlacard=0'"/>
				</td>
			</tr>
			<tr>
				<td>CARRIER
					<select name="carrier" id="carrier" tabindex="2" onChange="loadFromAddressOnChange()" data-placeholder="Select carrier..." style="width:200px;">
						<option></option>
						<cfloop query = "qCarriers">
							<option value = "#carrier# - #shipping_method#">#carrier# - #shipping_method#</option>
						</cfloop>
					</select>
				</td>
			</tr>
		</table>
	</cfform>
</cfoutput>