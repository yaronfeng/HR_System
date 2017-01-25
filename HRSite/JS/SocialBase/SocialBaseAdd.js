$(document).ready(function () {
    //绑定
    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCityId").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    $("#txbSocName").jqxInput({ minLength: 1, height: 25, width: 200 });

    $("#numPensionInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right"});
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

    $("#btnCreate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        if (!confirm("确认新增社保比例？")) { return; }

        var socialBase = {
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
            HouseFundINum: $("#numHouseFundINum").val(),
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
            url: "../SocialBase/Insert",
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