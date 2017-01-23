$(document).ready(function () {
    //绑定
    $("#txbCorpName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpEName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpCode").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpAddress").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpContacts").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpTel").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpFax").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpZip").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCorpEmail").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbOrganizationCode").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbInternetPWD").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSocialRegCode").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbHousePWD").jqxInput({ minLength: 1, height: 25, width: 200 });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selHouseBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selPayCity").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#txbCorpName", message: "客户姓名必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbCorpName").val() != "";
                    }
                }
            ]
    });

    $("#btnCreate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        if (!confirm("确认新增客户？")) { return; }

        var corporation = {
            CorpCode: $("#txbCorpCode").val(),
            CorpName: $("#txbCorpName").val(),
            CorpEName: $("#txbCorpEName").val(),
            CorpAddress: $("#txbCorpAddress").val(),
            CorpContacts: $("#txbCorpContacts").val(),
            CorpTel: $("#txbCorpTel").val(),
            CorpFax: $("#txbCorpFax").val(),
            CorpZip: $("#txbCorpZip").val(),
            CorpEmail: $("#txbCorpEmail").val(),
            OrganizationCode: $("#txbOrganizationCode").val(),
            InternetPWD: $("#txbInternetPWD").val(),
            SocialRegCode: $("#txbSocialRegCode").val(),
            PayCity: $("#selPayCity").val(),
            HouseAccount: $("#txbHouseAccount").val(),
            HouseBank: $("#selHouseBank").val(),
            HousePWD: $("#txbHousePWD").val(),
            Memo: $("#txbMemo").val()
        };

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../Corporation/Insert",
            data: JSON.stringify(corporation),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
                if (obj.ResultStatus == 0) {
                    window.location = "/Corporation/CorporationList";
                }
            }
        });

    });
});