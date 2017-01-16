$(document).ready(function () {
    //绑定
    $("#txbEmpName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCardNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbAddress").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbJobs").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbContractNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbInsCardNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbEmpEmail").jqxInput({ minLength: 1, height: 25, width: 200 });

    $("#tmEntryDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });

    $("#tmConStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmConEndDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmLeaveDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" ,value: new Date(1900, 0, 1)});
    $("#tmSocialStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmHouseStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmEmployDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmSocialSignDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1) });

    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numSocialFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numHouseFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });

    $("#selSex").jqxDropDownList({ source: SexSource, displayMember: "text", valueMember: "value",autoDropDownHeight: true, selectedIndex: 0 });

    $("#selDegree").jqxDropDownList({ source: DegreeSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

    $("#selBank").jqxDropDownList({ source: BankSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

    $("#selPayCity").jqxDropDownList({ source: PayCitySource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });

    var outCorpUrl = "../Corporation/Corps";
    var outCorpSource = { datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: outCorpUrl };
    var outCorpDataAdapter = new $.jqx.dataAdapter(outCorpSource);
    $("#selCorpId").jqxComboBox({ source: outCorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25 });

    $("#chkIsHandBook").jqxCheckBox();
    $("#chkIsResidentPermit").jqxCheckBox();
    $("#chkIsBirthIns").jqxCheckBox();


    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#txbEmpName", message: "员工姓名必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbEmpName").val() != "";
                    }
                },
                {
                    input: "#txbCardNo", message: "身份证必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbCardNo").val() != "";
                    }
                }
            ]
    });


    $("#btnCreate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        var employee = {
            EmpName: $("#txbEmpName").val(),
            Sex: $("#selSex").val(),
            CardNo: $("#txbCardNo").val(),
            Address: $("#txbAddress").val(),
            Phone: $("#txbPhone").val(),
            EntryDate: $("#tmEntryDate").val(),
            ConStartDate: $("#tmConStartDate").val(),
            ConEndDate: $("#tmConEndDate").val(),
            LeaveDate: $("#tmLeaveDate").val(),
            Degree: $("#selDegree").val(),
            Jobs: $("#txbJobs").val(),
            TotalAmount: $("#numTotalAmount").val(),
            SocialFundNum: $("#numSocialFundNum").val(),
            HouseFundNum: $("#numHouseFundNum").val(),
            PayCity: $("#selPayCity").val(),
            SocialStartDate: $("#tmSocialStartDate").val(),
            HouseStartDate: $("#tmHouseStartDate").val(),
            HouseAccount: $("#txbHouseAccount").val(),
            HandBook: $("#chkIsHandBook").val(),
            ResidentPermit: $("#chkIsResidentPermit").val(),
            Bank: $("#selBank").val(),
            BankAccount: $("#txbBankAccount").val(),
            ContractNo: $("#txbContractNo").val(),
            EmployDate: $("#tmEmployDate").val(),
            SocialSignDate: $("#tmSocialSignDate").val(),
            IsBirthIns: $("#chkIsBirthIns").val(),
            InsCardNo: $("#txbInsCardNo").val(),
            EmpEmail: $("#txbEmpEmail").val(),
            Memo: $("#txbMemo").val()
        };

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../Employee/Insert",
            data: JSON.stringify(employee),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj);
            }
        });

    });
});