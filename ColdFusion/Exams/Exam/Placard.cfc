<cfcomponent>

	<!---Get Location By ID --->
	<cffunction name="getLocation" returntype="Query">
		<cfargument name="ID" type="numeric" />
		<cfquery name="qGetLocation">
			SELECT
				*
			FROM
				`Location`
			WHERE
				`loc_ID` = #ARGUMENTS.ID#
		</cfquery>

		<cfreturn qGetLocation />
	</cffunction>

	<!---Get Warehouse Locations --->
	<cffunction name="getLocations" access="remote" returntype="Query" >
		<cfargument name="type" default="0" />
		<cfargument name="includeSP" default="1" />

		<cfquery name="qGetLocations">
			SELECT
				*
			FROM
				`Exam`.`Location`
			WHERE
				`loc_isActive` = 1
			<cfif ARGUMENTS.type EQ 1>
			AND
				`loc_TypeID` = 1

				<cfif ARGUMENTS.includeSP is 0>
				AND
					`loc_ID` != 11
				</cfif>

				ORDER BY `loc_WarehouseOrder` ASC
			<cfelseif ARGUMENTS.type EQ 3>
			AND
				`loc_TypeID` = 3
			</cfif>
		</cfquery>

		<cfreturn qGetLocations />
	</cffunction>

    <cffunction name="getLocationData" returntype="any"  returnformat="JSON" >
        <cfargument name="searchInput" type="string" required="true" />
        <cfargument name="dataField" type="string" required="yes" default="" />

        <cfset sItems = '' />

        <cfif len(ARGUMENTS.searchInput) gt 0>
        	<cfquery name="qGetData">
                SELECT
                    *
                FROM
                    `Location`
                WHERE
                    `loc_Company` != ""
                AND
                    <cfif isNumeric(ARGUMENTS.searchInput)>
                    	loc_ID = #ARGUMENTS.searchInput#
                    <cfelse>
                    	`loc_Company` LIKE <cfqueryparam value="#ARGUMENTS.searchInput#%" cfsqltype="cf_sql_varchar" />
                    </cfif>

            </cfquery>

            <cfif qGetData.recordCount is 1>
				<cfif ARGUMENTS.dataField is 'address1'>
                	<cfset sItems = qGetData["loc_Address"] />
                <cfelseif ARGUMENTS.dataField is 'address2'>
                	<cfset sItems = qGetData["loc_Address2"] />
                <cfelseif ARGUMENTS.dataField is 'city'>
                	<cfset sItems = qGetData["loc_City"]/>
                <cfelseif ARGUMENTS.dataField is 'state'>
					<cfset sItems = qGetData["loc_State"] />
                <cfelseif ARGUMENTS.dataField is 'zip'>
                	<cfset sItems = Left(qGetData.loc_ZipCode, 5) />
                <cfelseif ARGUMENTS.dataField is 'telephone'>
                	<cfset sItems = qGetData.loc_Phone />
                </cfif>
            </cfif>
		</cfif>

        <cfreturn sItems>
    </cffunction>

	<cffunction name="getPlacard" returntype="query">
		<cfargument name="placardID" type="numeric" required="false" default="0" />

		<cfquery name="qGetPlacardData">
			SELECT
				*
			FROM
				`Placard`
			<cfif ARGUMENTS.placardID NEQ "0">
				WHERE
					`plac_ID` = <cfqueryparam value="#ARGUMENTS.placardID#" cfsqltype="cf_sql_integer" />
			</cfif>
		</cfquery>

		<cfreturn qGetPlacardData />
	</cffunction>

	<cffunction name="getPlacards" returntype="query">
		<cfargument name="placardID" type="numeric" required="false" default="0" />

		<cfquery name="qGetPlacards">
			SELECT
                `plac_ID`,
                `plac_fromCompany`,
                `plac_toCompany`,
                `plac_toAddress1`,
                `plac_toCity`,
                `plac_toState`,
                `plac_toZip`,
                `plac_Pallets`
			FROM
				`Placard`
            GROUP BY
            	`plac_fromCompany`,
                `plac_toCompany`,
                `plac_toAddress1`,
                `plac_toCity`,
                `plac_toState`,
                `plac_toZip`
            ORDER BY
            	`plac_toCompany` ASC
		</cfquery>

		<cfreturn qGetPlacards />
	</cffunction>

    <cffunction name="getPlacardData" returntype="any"  returnformat="JSON" >
        <cfargument name="searchInput" type="string" required="true" />
        <cfargument name="dataField" type="string" required="yes" default="" />

        <cfset sItems = '' />

        <cfif len(ARGUMENTS.searchInput) gt 2>
        	<cfquery name="qGetData">
                SELECT
                    *
                FROM
                    `Order`
                INNER JOIN
                (
                    SELECT
                        *
                    FROM
                        `Track`
                    WHERE
                        `track_isManual` = "1"
                ) AS trackTable ON `track_OrderID`=`ord_ID`
                WHERE
                    `ord_shipCompanyName` != ""
                AND
                    `ord_shipCompanyName` LIKE <cfqueryparam value="#ARGUMENTS.searchInput#" cfsqltype="cf_sql_varchar" />
                LIMIT 1
            </cfquery>
            <cfif qGetData.recordCount is 1>
				<cfif ARGUMENTS.dataField is 'attentionTo'>
                	<cfset sItems = qGetData.ord_shipFirstName & " " & qGetData.ord_shipLastName />
				<cfelseif ARGUMENTS.dataField is 'address1'>
                	<cfset sItems = qGetData["ord_shipAddress1"] />
                <cfelseif ARGUMENTS.dataField is 'address2'>
                	<cfset sItems = qGetData["ord_shipAddress2"] />
                <cfelseif ARGUMENTS.dataField is 'city'>
                	<cfset sItems = qGetData["ord_shipCity"]/>
                <cfelseif ARGUMENTS.dataField is 'state'>
					<cfset sItems = qGetData["ord_shipState"] />
                <cfelseif ARGUMENTS.dataField is 'zip'>
                	<cfset sItems = Left(qGetData.ord_shipPostalCode, 5) />
                <cfelseif ARGUMENTS.dataField is 'telephone'>
                	<cfset sItems = qGetData["ord_shipPhoneNumber"] />
                </cfif>
            </cfif>
		</cfif>

        <cfreturn sItems>
    </cffunction>

    <cffunction name="getConsignees" returntype="any"  returnformat="JSON" >
		<cfargument name="searchInput" type="string" required="true" />

		<cfquery name="qGetConsignees">
			SELECT
				DISTINCT `ord_shipCompanyName` AS ord_shipCompanyName
			FROM
				`Order`
			INNER JOIN
			(
				SELECT
					*
				FROM
					`Track`
				WHERE
					`track_isManual` = "1"
			) AS trackTable ON `track_OrderID`=`ord_ID`
			WHERE
				`ord_shipCompanyName` != ""
			AND
				`ord_shipCompanyName` LIKE <cfqueryparam value="#ARGUMENTS.searchInput#%" cfsqltype="cf_sql_varchar" />
			LIMIT 10
		</cfquery>

		<cfset sItems = '[' />
		<cfloop query="qGetConsignees" >
			<cfif qGetConsignees.CurrentRow EQ qGetConsignees.RecordCount>
				<cfset sItems &= '{"value":"#ord_shipCompanyName#"}'>
			<cfelse>
				<cfset sItems &= '{"value":"#ord_shipCompanyName#"},'>
			</cfif>
		</cfloop>

		<cfset sItems &= ']'>

		<cfreturn sItems>
	</cffunction>

    <cffunction name="savePlacard" returntype="any">
		<cfargument name="placardData" type="struct" required="true"/>

        <cfset theData = ARGUMENTS.placardData>

		<cfquery name="qSavePlacard" result="result">
			INSERT INTO `Placard`
				(
					`plac_fromCompany`,
					`plac_fromAddress1`,
					`plac_fromAddress2`,
					`plac_fromCity`,
					`plac_fromState`,
					`plac_fromZip`,
					`plac_fromTelephone`,
					`plac_toCompany`,
					`plac_toAttentionTo`,
					`plac_toAddress1`,
					`plac_toAddress2`,
					`plac_toCity`,
					`plac_toState`,
					`plac_toZip`,
					`plac_toCountry`,
					`plac_toTelephone`,
					`plac_TrackingNumber`,
					`plac_PO`,
					`plac_Pallets`,
					`carrier`
				)
			VALUES
				(
					<cfqueryparam value="#theData.fromCompany#"     cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromAddress1#"  	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromAddress2#"  	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromCity#"      	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromState#"     	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromZip#"       	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.fromTelephone#"   cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toCompany#"		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toAttentionTo#"   cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toAddress1#" 		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toAddress2#" 		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toCity#"     		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toState#"    		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toZip#"      		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toCountry#"  		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.toTelephone#"    	cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.TrackingNumber#"  cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.PO#"       		cfsqltype="cf_sql_varchar" />,
					<cfqueryparam value="#theData.pallets#"         cfsqltype="cf_sql_integer" />,
					<cfqueryparam value="#theData.carrier#" 		cfsqltype="cf_sql_varchar" />
				)
		</cfquery>

		<cfset updateKey = result.GENERATED_KEY />

		<cfreturn updateKey />
	</cffunction>

	<cffunction name = "getSimilarPlacards" returntype = "string">
		<cfargument name = "placardID" type = "numeric" required = "true" />
		<cfset var qPlacard = getPlacard(placardID = ARGUMENTS.placardID) />
		<cfset var qSimilarPlacards = queryNew("")/>
		<cfquery name = "qSimilarPlacards">
			SELECT
				`plac_ID`
			FROM
				`Placard`
			WHERE
				`plac_fromCompany` =
				<cfqueryparam
					value = "#qPlacard.plac_fromCompany#"
					cfsqltype = "cf_sql_varchar"
				/>
			AND
				`plac_toCompany` =
				<cfqueryparam
					value = "#qPlacard.plac_toCompany#"
					cfsqltype = "cf_sql_varchar"
				/>
			AND
				`plac_toAddress1` =
				<cfqueryparam
					value = "#qPlacard.plac_toAddress1#"
					cfsqltype = "cf_sql_varchar"
				/>
			AND
				`plac_toCity` =
				<cfqueryparam
					value = "#qPlacard.plac_toCity#"
					cfsqltype = "cf_sql_varchar"
				/>
			AND
				`plac_toState` =
				<cfqueryparam
					value = "#qPlacard.plac_toState#"
					cfsqltype = "cf_sql_varchar"
				/>
			AND
				`plac_toZip` =
				<cfqueryparam
					value = "#qPlacard.plac_toZip#"
					cfsqltype = "cf_sql_varchar"
				/>
		</cfquery>
		<cfreturn valueList(qSimilarPlacards.plac_ID) />
	</cffunction>

    <cffunction name="deletePlacard" access="public">
		<cfargument name="placardID" type="numeric" required="true"/>

		<!--- GET ALL PLACARDS WITH CURRENT ADDRESS --->
		<cfset var similarPlacards = getSimilarPlacards(placardID = ARGUMENTS.placardID) />

		<cfquery name="qGetPlacards">
			DELETE FROM
				`Placard`
			WHERE
				`plac_ID` IN (
				<cfqueryparam
					value="#similarPlacards#"
					cfsqltype="cf_sql_integer"
					list = true
				/>)
		</cfquery>

	</cffunction>

	<cffunction name="getCarriers" returntype="query">
		<cfquery name="qGetCarriers">
			SELECT carrier, shipping_method FROM carrier_shipping_method
		</cfquery>

		<cfreturn qGetCarriers />
	</cffunction>

	<cffunction name="getPlacardsByCompany" returntype="query">
		<cfargument name="companyName" type="string" required="true" />

		<cfquery name="qGetPlacardsByCompany">
			SELECT * FROM placard
			WHERE plac_fromCompany = <cfqueryparam value="#arguments.companyName#" cfsqltype="cf_sql_varchar" />
		</cfquery>

		<cfreturn qGetPlacardsByCompany />
	</cffunction>

</cfcomponent>