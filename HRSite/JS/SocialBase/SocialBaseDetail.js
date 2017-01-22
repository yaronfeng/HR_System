$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#selCityId").jqxDropDownList({ source: PayCitySource, displayMember: "text", valueMember: "value", autoDropDownHeight: true, selectedIndex: 0 ,disabled:true});
    $("#txbSocName").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    $("#numSocialFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numHouseFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numCorpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numCorpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });

    $("#numEmpPensionInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpMedicalInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpUnempInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpBirthInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpDisabledInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpIllnessInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpHeatAmountPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpHouseFundPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });
    $("#numEmpRepInjuryInsPoint").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, inputMode: 'simple', symbol: "%", symbolPosition: "right", disabled: true });


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
});