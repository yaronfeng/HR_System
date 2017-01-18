$(document).ready(function () {
    var id = $("#hidId").val();
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

    $("#selBank").jqxDropDownList({ source: BankSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

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

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Supplier/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#txbSupName").val(rtnObj.SupName),
                $("#txbSupEName").val(rtnObj.SupEName),
                $("#txbSupCode").val(rtnObj.SupCode),
                $("#txbSupAddress").val(rtnObj.SupAddress),
                $("#txbSupContacts").val(rtnObj.SupContacts),
                $("#txbSupTel").val(rtnObj.SupTel),
                $("#txbSupFax").val(new Date(rtnObj.SupFax)),
                $("#txbSupZip").val(new Date(rtnObj.SupZip)),
                $("#txbSupEmail").val(new Date(rtnObj.SupEmail)),
                $("#txbBankAccount").val(new Date(rtnObj.BankAccount)),
                $("#txbServiceAmount").val(rtnObj.ServiceAmount),
                $("#txbMemo").val(rtnObj.Memo)
            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });

    $("#btnUpdate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        var employee = {
            SupId:id,
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
            url: "../Supplier/Update",
            data: JSON.stringify(employee),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
            }
        });

    });
});