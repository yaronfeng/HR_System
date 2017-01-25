$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCityId").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    $("#txbSocName").jqxInput({ minLength: 1, height: 25, width: 200 });

    $("#numPensionInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numPensionInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numMedicalInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numMedicalInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numUnempInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numUnempInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numInjuryInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numInjuryInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numBirthInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numBirthInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numDisabledInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numDisabledInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numIllnessInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numIllnessInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numHeatAmountNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numHeatAmountFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numHouseFundINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numHouseFundFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });

    $("#numRepInjuryInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });
    $("#numCorpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numEmpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right" });
    $("#numRepInjuryInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right" });


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

                $("#numPensionInsNum").val(rtnObj.PensionInsNum),
                $("#numMedicalInsNum").val(rtnObj.MedicalInsNum),
                $("#numUnempInsNum").val(rtnObj.UnempInsNum),
                $("#numInjuryInsNum").val(rtnObj.InjuryInsNum),
                $("#numBirthInsNum").val(rtnObj.BirthInsNum),
                $("#numDisabledInsNum").val(rtnObj.DisabledInsNum),
                $("#numIllnessInsNum").val(rtnObj.IllnessInsNum),
                $("#numHeatAmountNum").val(rtnObj.HeatAmountNum),
                $("#numHouseFundNum").val(rtnObj.HouseFundNum),
                $("#numRepInjuryInsNum").val(rtnObj.RepInjuryInsNum),

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
                $("#numEmpRepInjuryInsPoint").val(rtnObj.EmpRepInjuryInsPoint),

                $("#numPensionInsFix").val(rtnObj.PensionInsFix),
                $("#numMedicalInsFix").val(rtnObj.MedicalInsFix),
                $("#numUnempInsFix").val(rtnObj.UnempInsFix),
                $("#numInjuryInsFix").val(rtnObj.InjuryInsFix),
                $("#numBirthInsFix").val(rtnObj.BirthInsFix),
                $("#numDisabledInsFix").val(rtnObj.DisabledInsFix),
                $("#numIllnessInsFix").val(rtnObj.IllnessInsFix),
                $("#numHeatAmountFix").val(rtnObj.HeatAmountFix),
                $("#numHouseFundFix").val(rtnObj.HouseFundFix),
                $("#numRepInjuryInsFix").val(rtnObj.RepInjuryInsFix)
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

            PensionInsNum: $("#numPensionInsNum").val(),
            MedicalInsNum: $("#numMedicalInsNum").val(),
            UnempInsNum: $("#numUnempInsNum").val(),
            InjuryInsNum: $("#numInjuryInsNum").val(),
            BirthInsNum: $("#numBirthInsNum").val(),
            DisabledInsNum: $("#numDisabledInsNum").val(),
            IllnessInsNum: $("#numIllnessInsNum").val(),
            HeatAmountNum: $("#numHeatAmountNum").val(),
            HouseFundNum: $("#numHouseFundNum").val(),
            RepInjuryInsNum: $("#numRepInjuryInsNum").val(),

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

            PensionInsFix: $("#numPensionInsFix").val(),
            MedicalInsFix: $("#numMedicalInsFix").val(),
            UnempInsFix: $("#numUnempInsFix").val(),
            InjuryInsFix: $("#numInjuryInsFix").val(),
            BirthInsFix: $("#numBirthInsFix").val(),
            DisabledInsFix: $("#numDisabledInsFix").val(),
            IllnessInsFix: $("#numIllnessInsFix").val(),
            HeatAmountFix: $("#numHeatAmountFix").val(),
            HouseFundFix: $("#numHouseFundFix").val(),
            RepInjuryInsFix: $("#numRepInjuryInsFix").val(),
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
                if (obj.ResultStatus == 0) {
                    window.location = "/SocialBase/SocialBaseList";
                }
            }
        });

    });
});