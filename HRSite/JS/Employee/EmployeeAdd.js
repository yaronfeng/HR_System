$(document).ready(function () {
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
    $("#tmLeaveDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmSocialStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmHouseStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmEmployDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmSocialSignDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });

    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numSocialFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numHouseFundNum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });

    var currencyUrl = "../BaseData/sex.txt";
    var currencySource = { datatype: "json", datafields: [{ name: "SexId" }, { name: "SexName" }], url: currencyUrl, async: false };
    var currencyDataAdapter = new $.jqx.dataAdapter(currencySource);
    $("#selSex").jqxComboBox({ source: currencyDataAdapter, displayMember: "SexName", valueMember: "SexId", autoComplete: true, searchMode: "contains", selectedIndex: 0 });

    var currencyUrl = "../BaseData/degree.txt";
    var currencySource = { datatype: "json", datafields: [{ name: "DegreeId" }, { name: "DegreeName" }], url: currencyUrl, async: false };
    var currencyDataAdapter = new $.jqx.dataAdapter(currencySource);
    $("#SelDegree").jqxComboBox({ source: currencyDataAdapter, displayMember: "DegreeName", valueMember: "DegreeId", autoComplete: true, searchMode: "contains", selectedIndex: 0 });

    var currencyUrl = "../BaseData/bank.txt";
    var currencySource = { datatype: "json", datafields: [{ name: "BankId" }, { name: "BankName" }], url: currencyUrl, async: false };
    var currencyDataAdapter = new $.jqx.dataAdapter(currencySource);
    $("#selBank").jqxComboBox({ source: currencyDataAdapter, displayMember: "BankName", valueMember: "BankId", autoComplete: true, searchMode: "contains"});

    var currencyUrl = "../BaseData/payCity.txt";
    var currencySource = { datatype: "json", datafields: [{ name: "payCityId" }, { name: "payCityName" }], url: currencyUrl, async: false };
    var currencyDataAdapter = new $.jqx.dataAdapter(currencySource);
    $("#selPayCity").jqxComboBox({ source: currencyDataAdapter, displayMember: "payCityName", valueMember: "payCityId", autoComplete: true, searchMode: "contains", selectedIndex: 0 });

    $("#chkIsHandBook").jqxCheckBox();
    $("#chkIsResidentPermit").jqxCheckBox();
    $("#chkIsBirthIns").jqxCheckBox();
});