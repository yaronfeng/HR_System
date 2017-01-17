$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#txbEmpName").jqxInput({ minLength: 1, height: 25, width: 200 ,disabled:true});
    $("#txbCardNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbAddress").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbJobs").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbContractNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbInsCardNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbEmpEmail").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    $("#tmEntryDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });

    $("#tmConStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmConEndDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmLeaveDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1), disabled: true });
    $("#tmSocialStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmHouseStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmEmployDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmSocialSignDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1), disabled: true });

    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numSocialFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numHouseFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });

    $("#selSex").jqxDropDownList({ source: SexSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0, disabled: true });

    $("#selDegree").jqxDropDownList({ source: DegreeSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0, disabled: true });

    $("#selBank").jqxDropDownList({ source: BankSource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0, disabled: true });

    $("#selPayCity").jqxDropDownList({ source: PayCitySource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0, disabled: true });

    $("#chkIsHandBook").jqxCheckBox({ disabled: true });
    $("#chkIsResidentPermit").jqxCheckBox({ disabled: true });
    $("#chkIsBirthIns").jqxCheckBox({ disabled: true });

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Employee/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#txbEmpName").val(rtnObj.EmpName),
                $("#selSex").val(rtnObj.Sex),
                $("#selCorpId").val(rtnObj.CorpId),
                $("#txbCardNo").val(rtnObj.CardNo),
                $("#txbAddress").val(rtnObj.Address),
                $("#txbPhone").val(rtnObj.Phone),
                $("#tmEntryDate").val(new Date(rtnObj.EntryDate)),
                $("#tmConStartDate").val(new Date(rtnObj.ConStartDate)),
                $("#tmConEndDate").val(new Date(rtnObj.ConEndDate)),
                $("#tmLeaveDate").val(new Date(rtnObj.LeaveDate)),
                $("#selDegree").val(rtnObj.Degree),
                $("#txbJobs").val(rtnObj.Jobs),
                $("#numTotalAmount").val(rtnObj.TotalAmount),
                $("#numSocialFundNum").val(rtnObj.SocialFundNum),
                $("#numHouseFundNum").val(rtnObj.HouseFundNum),
                $("#selPayCity").val(rtnObj.PayCity),
                $("#tmSocialStartDate").val(new Date(rtnObj.SocialStartDate)),
                $("#tmHouseStartDate").val(new Date(rtnObj.HouseStartDate)),
                $("#txbHouseAccount").val(rtnObj.HouseAccount),
                $("#chkIsHandBook").val(rtnObj.HandBook),
                $("#chkIsResidentPermit").val(rtnObj.ResidentPermit),
                $("#selBank").val(rtnObj.Bank),
                $("#txbBankAccount").val(rtnObj.BankAccount),
                $("#txbContractNo").val(rtnObj),
                $("#tmEmployDate").val(new Date(rtnObj.EmployDate)),
                $("#tmSocialSignDate").val(new Date(rtnObj.SocialSignDate)),
                $("#chkIsBirthIns").val(rtnObj.IsBirthIns),
                $("#txbInsCardNo").val(rtnObj.InsCardNo),
                $("#txbEmpEmail").val(rtnObj.EmpEmail),
                $("#txbMemo").val(rtnObj.Memo)
            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });
});