$(document).ready(function () {
    //绑定
    $("#txbSupName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupEName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupCode").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupAddress").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupContacts").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupTel").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupFax").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupZip").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbSupEmail").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbServiceAmount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbMemo").jqxInput({ minLength: 1, height: 25, width: 200 });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#txbSupName", message: "供应商名称必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbSupName").val() != "";
                    }
                }
            ]
    });

    $("#btnCreate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        var employee = {
            SupCode: $("#txbSupCode").val(),
            SupName: $("#txbSupName").val(),
            SupEName: $("#txbSupEName").val(),
            SupAddress: $("#txbSupAddress").val(),
            SupContacts: $("#txbSupContacts").val(),
            SupTel: $("#txbSupTel").val(),
            SupFax: $("#txbSupFax").val(),
            SupZip: $("#txbSupZip").val(),
            SupEmail: $("#txbSupEmail").val(),
            Bank: $("#selBank").val(),
            BankAccount: $("#txbBankAccount").val(),
            ServiceAmount: $("#txbServiceAmount").val(),
            Memo: $("#txbMemo").val()
        };

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../Supplier/Insert",
            data: JSON.stringify(employee),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
            }
        });

    });
});