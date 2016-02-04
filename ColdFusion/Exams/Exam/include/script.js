// datatables setup
$(document).ready(function() {
    //select2 part
    $("select").select2();    

    //datatables part
    $('#placards').dataTable({
        "iDisplayLength": 25,        
        "sDom": '<"top"f>rt<"bottom"p><"clear">',
        "bStateSave": true
    	});
} );

function getLocationList(){
  var locInp = $("#shipCompanyName").val(); 
  
  $( "#fromCompany" ).autocomplete({
    
    source:"ajax.cfm?action=update&locInput="+locInp,
    minLength: 3
  });
}

function getLocation(){
    var locInp = $("#fromCompany").val();
    
    $.post("ajax.cfm?action=setDataAddress1&locInput=" + locInp, function(dataAddress1){
        $("#fromAddress1").val(dataAddress1.trim());
    });
	
    loadAddressOnChange
    $.post("ajax.cfm?action=setDataAddress2&locInput=" + locInp, function(dataAddress2){
        $("#fromAddress2").val(dataAddress2.trim());
    });
    
    $.post("ajax.cfm?action=setDataCity&locInput=" + locInp, function(dataCity){
        $("#fromCity").val(dataCity.trim());
    });
    
    $.post("ajax.cfm?action=setDataState&locInput=" + locInp, function(dataState){
        $("#fromState").val(dataState.trim());
    });
    
    $.post("ajax.cfm?action=setDataZip&locInput=" + locInp, function(dataZip){
        $("#fromZip").val(dataZip.trim());
    });
    
    $.post("ajax.cfm?action=setDataPhone&locInput=" + locInp, function(dataPhone){
        $("#fromTelephone").val(dataPhone.trim());
    });
}



$("#toCompany").on('input', function(){

    var locInp = $("#toCompany").val();

    $( "#toCompany" ).autocomplete({
        source:"ajax.cfm?action=consUpdate&locInput="+locInp,
        minLength: 3
    });
});

$("#toCompany").on('change', function(){
    
    var locInp = $("#toCompany").val();
    
    if($("#toAddress1").val()===""){
       
        $.post("ajax.cfm?action=setConsAttnTo&locInput=" + locInp, function(consAttnTo){
            $("#toAttentionTo").val(consAttnTo.trim());
        });
        
        $.post("ajax.cfm?action=setConsAddress1&locInput=" + locInp, function(consAddress1){
            $("#toAddress1").val(consAddress1.trim());
        });
     
        $.post("ajax.cfm?action=setConsAddress2&locInput=" + locInp, function(consAddress2){
            $("#toAddress2").val(consAddress2.trim());
        });
        
        $.post("ajax.cfm?action=setConsCity&locInput=" + locInp, function(consCity){
            $("#toCity").val(consCity.trim());
        });
        
        $.post("ajax.cfm?action=setConsState&locInput=" + locInp, function(consState){
            $("#toState").val(consState.trim());
        });
        
        $.post("ajax.cfm?action=setConsZip&locInput=" + locInp, function(consZip){
            $("#toZip").val(consZip.trim());
        });
        
        $.post("ajax.cfm?action=setConsPhone&locInput=" + locInp, function(consPhone){
            $("#toTelephone").val(consPhone.trim());
        });
       
    }

});

function loadFromAddressOnChange(){
    var locInp = $("#locationID").val();

    $.post("ajax.cfm?action=setDataSecRqstAddress1&locInput=" + locInp, function(dataSecRqstAddress1){
        $("#fromAddress1").val(dataSecRqstAddress1.trim());
    });
    
    $.post("ajax.cfm?action=setDataSecRqstAddress2&locInput=" + locInp, function(dataSecRqstAddress2){
        $("#fromAddress2").val(dataSecRqstAddress2.trim());
    });
    
    $.post("ajax.cfm?action=setDataSecRqstCity&locInput=" + locInp, function(dataSecRqstCity){
        $("#fromCity").val(dataSecRqstCity.trim());
    });
    
    $.post("ajax.cfm?action=setDataSecRqstState&locInput=" + locInp, function(dataSecRqstState){
        $("#fromState").val(dataSecRqstState.trim());
    });
    
    $.post("ajax.cfm?action=setDataSecRqstZip&locInput=" + locInp, function(dataSecRqstZip){
        $("#fromZip").val(dataSecRqstZip.trim());
    });
	
	$.post("ajax.cfm?action=setDataSecRqstTel&locInput=" + locInp, function(dataSecRqstTel){
        $("#fromTelephone").val(dataSecRqstTel.trim());
    });
}

function loadToAddressOnChange(){
    var locInp = $("#consLocationSelect").val();

    $.post("ajax.cfm?action=setDataSecRqstAddress1&locInput=" + locInp, function(dataSecRqstAddress1){
        $("#consAddress1").val(dataSecRqstAddress1.trim());
    });
    
    $.post("ajax.cfm?action=setDataSecRqstAddress2&locInput=" + locInp, function(dataSecRqstAddress2){
        $("#consAddress2").val(dataSecRqstAddress2.trim());

    });
    
    $.post("ajax.cfm?action=setDataSecRqstCity&locInput=" + locInp, function(dataSecRqstCity){
        $("#consCity").val(dataSecRqstCity.trim());

    });
    
    $.post("ajax.cfm?action=setDataSecRqstState&locInput=" + locInp, function(dataSecRqstState){
        $("#consState").val(dataSecRqstState.trim());

    });
    
    $.post("ajax.cfm?action=setDataSecRqstZip&locInput=" + locInp, function(dataSecRqstZip){
        $("#consZip").val(dataSecRqstZip.trim());

    });

}