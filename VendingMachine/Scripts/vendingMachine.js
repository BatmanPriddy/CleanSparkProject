function AddMoney()
{
    const increment = $('#increment').val();

    const data = { Increment: increment };

    SetData('/VendingMachine/AddMoney', "POST", data);
}

function DispenseCoffee()
{
    const coffeeList = $('#coffeeList').html();

    if (coffeeList !== "")
    {
        SetData('/VendingMachine/DispenseCoffee', "POST", null);
    }
    else
    {
        alert('Please Add Coffee to your order.');
    }
}

function AddCoffee()
{
    const size = $('#size option:selected').text();

    const cost = $('#size').val();

    const sugars = $('#sugars').val();

    const creamers = $('#creamers').val();

    const data =
    {
        Size: size,
        Cost: cost,
        Sugars: sugars,
        Creamers: creamers
    };

    SetData('/VendingMachine/AddCoffee', "POST", data);
}

function DispenseChange()
{
    const remainingAmount = $('#remainingAmount').text();

    if (remainingAmount > 0)
    {
        SetData('/VendingMachine/DispenseChange', "POST", null);
    }
    else
    {
        alert("There is no remaining amount.");
    }
}

function SetData(url, type, data)
{
    $.ajax({
        url: url,
        dataType: "json",
        type: type,
        contentType: 'application/json; charset=utf-8',
        data: (data != null) ? JSON.stringify(data) : null,
        async: true,
        processData: false,
        cache: false,
        success: function(data)
        {
            UpdateUI(url, data);
        }
    });
}

//This method could be shortened a bit by breaking it up
function UpdateUI(url, data)
{
    if (url.indexOf("AddMoney") !== -1)
    {
        $('#remainingAmount').text(data.toFixed(2));
    }
    else if (url.indexOf("DispenseCoffee") !== -1)
    {
        DispenseCoffeeUI(data);
    }
    else if (url.indexOf("AddCoffee") !== -1)
    {
        AddCoffeeUI(data);
    }
    else if (url.indexOf("DispenseChange") !== -1)
    {
        DispenseChangeUI(data);
    }
}

//convenience function(s) for reusable code
function DispenseCoffeeUI(data)
{
    alert(data.Message);

    if (!data.HasError)
    {
        $('#remainingAmount').text(data.RemainingAmount.toFixed(2));

        ResetDropDowns();

        EmptyCoffeeList();
    }
}

function AddCoffeeUI(data)
{
    var coffees = "<div>Coffee List:</div><br />";

    $.each(data, function(index, value)
    {
        coffees += "<div>";
        coffees += `Size: ${value.DisplaySize} | `;
        coffees += `Sugars: ${value.Sugars} | `;
        coffees += `Creamers: ${value.Creamers} | `;
        coffees += `Cost: ${value.Cost.toFixed(2)}`;
        coffees += "</div>";
    });

    $('#coffeeList').html(coffees);
}

function DispenseChangeUI(data)
{
    alert("Please collect your $" + data.toFixed(2));

    $('#remainingAmount').text(0);

    ResetDropDowns();

    EmptyCoffeeList();
}

function EmptyCoffeeList()
{
    $('#coffeeList').html("");
}

function ResetDropDowns()
{
    $('#size').prop('selectedIndex', 0);
    $('#sugars').prop('selectedIndex', 0);
    $('#creamers').prop('selectedIndex', 0);
    $('#increment').prop('selectedIndex', 0);
}
//convenience function(s) for reusable code