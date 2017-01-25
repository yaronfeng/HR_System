$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCityId").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 ,disabled:true});

    $("#txbSocName").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    $("#numPensionInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numPensionInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numMedicalInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numMedicalInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numUnempInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numUnempInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numInjuryInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numInjuryInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numBirthInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numBirthInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numDisabledInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numDisabledInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numIllnessInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numIllnessInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numHeatAmountNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numHeatAmountFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numHouseFundINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numHouseFundFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });

    $("#numRepInjuryInsNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });
    $("#numCorpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numRepInjuryInsFix").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbolPosition: "right", disabled: true });


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
});