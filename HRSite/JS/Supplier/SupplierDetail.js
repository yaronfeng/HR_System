$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#txbSupName").jqxInput({ minLength: 1, height: 25, width: 200,disabled:true });
    $("#txbSupEName").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupCode").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupAddress").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupContacts").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupTel").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupFax").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupZip").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbSupEmail").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbServiceAmount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbMemo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

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
});