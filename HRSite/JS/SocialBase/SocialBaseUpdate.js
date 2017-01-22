$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#selCityId").jqxDropDownList({ source: PayCitySource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 });
    $("#txbSocName").jqxInput({ minLength: 1, height: 25, width: 200 });

    $("#numSocialFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numHouseFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numCorpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numCorpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });

    $("#numEmpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });

    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#selCityId", message: "社保城市必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#selCityId").val() > 0;
                    }
                },
                {
                    input: "#txbSocName", message: "名称必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbSocName").val() != 0;
                    }
                },
                {
                    input: "#numSocialFundNum", message: "社保基数必须大于0", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#numSocialFundNum").val() > 0;
                    }
                }
                ,
                {
                    input: "#numHouseFundNum", message: "公积金基数必须大于0", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#numHouseFundNum").val() > 0;
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
        url: "/SocialBase/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#selCityId").val(rtnObj.CityId),
                $("#txbSocName").val(rtnObj.SocName),

                $("#numSocialFundNum").val(rtnObj.SocialFundNum),
                $("#numHouseFundNum").val(rtnObj.HouseFundNum),
                $("#numCorpPensionInsPoint").val(rtnObj.CorpPensionInsPoint),
                $("#numCorpMedicalInsPoint").val(rtnObj.CorpMedicalInsPoint),
                $("#numCorpUnempInsPoint").val(rtnObj.CorpUnempInsPoint),
                $("#numCorpInjuryInsPoint").val(rtnObj.CorpInjuryInsPoint),
                $("#numCorpBirthInsPoint").val(rtnObj.CorpBirthInsPoint),
                $("#numCorpDisabledInsPoint").val(rtnObj.CorpDisabledInsPoint),
                $("#numCorpIllnessInsPoint").val(rtnObj.CorpIllnessInsPoint),
                $("#numCorpHeatAmountPoint").val(rtnObj.CorpHeatAmountPoint),
                $("#numCorpHouseFundPoint").val(rtnObj.CorpHouseFundPoint),
                $("#numCorpRepInjuryInsPoint").val(rtnObj.CorpRepInjuryInsPoint),

                $("#numEmpPensionInsPoint").val(rtnObj.EmpPensionInsPoint),
                $("#numEmpMedicalInsPoint").val(rtnObj.EmpMedicalInsPoint),
                $("#numEmpUnempInsPoint").val(rtnObj.EmpUnempInsPoint),
                $("#numEmpInjuryInsPoint").val(rtnObj.EmpInjuryInsPoint),
                $("#numEmpBirthInsPoint").val(rtnObj.EmpBirthInsPoint),
                $("#numEmpDisabledInsPoint").val(rtnObj.EmpDisabledInsPoint),
                $("#numEmpIllnessInsPoint").val(rtnObj.EmpIllnessInsPoint),
                $("#numEmpHeatAmountPoint").val(rtnObj.EmpHeatAmountPoint),
                $("#numEmpHouseFundPoint").val(rtnObj.EmpHouseFundPoint),
                $("#numEmpRepInjuryInsPoint").val(rtnObj.EmpRepInjuryInsPoint)
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

        if (!confirm("确认修改社保比例？")) { return; }

        var socialBase = {
            SocId: id,
            CityId: $("#selCityId").val(),
            SocName: $("#txbSocName").val(),
            SocialFundNum: $("#numSocialFundNum").val(),
            HouseFundNum: $("#numHouseFundNum").val(),
            CorpPensionInsPoint: $("#numCorpPensionInsPoint").val(),
            CorpMedicalInsPoint: $("#numCorpMedicalInsPoint").val(),
            CorpUnempInsPoint: $("#numCorpUnempInsPoint").val(),
            CorpInjuryInsPoint: $("#numCorpInjuryInsPoint").val(),
            CorpBirthInsPoint: $("#numCorpBirthInsPoint").val(),
            CorpDisabledInsPoint: $("#numCorpDisabledInsPoint").val(),
            CorpIllnessInsPoint: $("#numCorpIllnessInsPoint").val(),
            CorpHeatAmountPoint: $("#numCorpHeatAmountPoint").val(),
            CorpHouseFundPoint: $("#numCorpHouseFundPoint").val(),
            CorpRepInjuryInsPoint: $("#numCorpRepInjuryInsPoint").val(),

            EmpPensionInsPoint: $("#numEmpPensionInsPoint").val(),
            EmpMedicalInsPoint: $("#numEmpMedicalInsPoint").val(),
            EmpUnempInsPoint: $("#numEmpUnempInsPoint").val(),
            EmpInjuryInsPoint: $("#numEmpInjuryInsPoint").val(),
            EmpBirthInsPoint: $("#numEmpBirthInsPoint").val(),
            EmpDisabledInsPoint: $("#numEmpDisabledInsPoint").val(),
            EmpIllnessInsPoint: $("#numEmpIllnessInsPoint").val(),
            EmpHeatAmountPoint: $("#numEmpHeatAmountPoint").val(),
            EmpHouseFundPoint: $("#numEmpHouseFundPoint").val(),
            EmpRepInjuryInsPoint: $("#numEmpRepInjuryInsPoint").val(),
        };

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../SocialBase/Update",
            data: JSON.stringify(socialBase),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
            }
        });

    });
});