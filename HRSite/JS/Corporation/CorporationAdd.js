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

    $("#selPayCity").jqxDropDownList({ source: PayCitySource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

    $("#selHouseBank").jqxDropDownList({ source: BankSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

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

        var corporation = {
            CorpCode: $("#txbCorpCode").val(),
            CorpName: $("#txbCorpName").val(),
            CorpEName: $("#txbCorpEName").val(),
            CorpAddress: $("#txbCorpAddress").val(),
            CorpContacts: $("#txbCorpContacts").val(),
            CorpTel: $("#tmCorpTel").val(),
            CorpFax: $("#tmCorpFax").val(),
            CorpZip: $("#tmCorpZip").val(),
            CorpEmail: $("#tmCorpEmail").val(),
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
                alert(obj);
            }
        });

    });
});