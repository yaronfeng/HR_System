$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#txbCorpName").jqxInput({ minLength: 1, height: 25, width: 200 ,disabled:true});
    $("#txbCorpEName").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpCode").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpAddress").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpContacts").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpTel").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpFax").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpZip").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbCorpEmail").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbOrganizationCode").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbInternetPWD").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSocialRegCode").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbHousePWD").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selHouseBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selPayCity").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Corporation/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#txbCorpName").val(rtnObj.CorpName),
                $("#txbCorpEName").val(rtnObj.CorpEName),
                $("#txbCorpCode").val(rtnObj.CorpCode),
                $("#txbCorpAddress").val(rtnObj.CorpAddress),
                $("#txbCorpContacts").val(rtnObj.CorpContacts),
                $("#txbCorpTel").val(rtnObj.CorpTel),
                $("#txbCorpFax").val(rtnObj.CorpFax),
                $("#txbCorpZip").val(rtnObj.CorpZip),
                $("#txbCorpEmail").val(rtnObj.CorpEmail),
                $("#txbOrganizationCode").val(rtnObj.OrganizationCode),
                $("#txbInternetPWD").val(rtnObj.InternetPWD),
                $("#selPayCity").val(rtnObj.PayCity),
                $("#txbInternetPWD").val(rtnObj.InternetPWD),
                $("#txbSocialRegCode").val(rtnObj.SocialRegCode),
                $("#selHouseBank").val(rtnObj.HouseBank),
                $("#txbHousePWD").val(rtnObj.HousePWD),
                $("#txbMemo").val(rtnObj.Memo)
            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });
});