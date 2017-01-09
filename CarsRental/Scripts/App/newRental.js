$(document).ready(function () {
    var vm = {
        carIds: []
    };

    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'customers',
        display: 'name',
        source: customers
    }).on("typeahead:select", function (e, customer) {
        vm.customerId = customer.id;
    });

    var cars = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/cars?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#car').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'cars',
        display: 'name',
        source: cars
    }).on("typeahead:select", function (e, car) {
        $("#cars").append("<li class='list-group-item'>" + car.name + "</li>");

        $("#car").typeahead("val", "");
        vm.carIds.push(car.id);
    });

    $.validator.addMethod("validCustomer", function () {
        return vm.customerId && vm.customerId !== 0;
    }, "Please select a valid customer.");

    $.validator.addMethod("validCar", function () {
        return vm.carIds.length > 0;
    }, "Please select at least one car.");

    $("#newRental").validate(
        function () {
            $.ajax({
                url: "/api/newRentals",
                method: "post",
                data: vm
            })
                .done(function () {
                    toastr.success("Rentals successfully recorded.");

                    $("#customer").typeahead("val", "");
                    $("#car").typeahead("val", "");
                    $("#cars").empty();

                    vm = { carIds: [] };

                })
                .fail(function () {
                    toastr.error("Something unexpected happened");
                });
            return false;
        }
    );

    $("#newRental").submit(
       function () {
           $.ajax({
               url: "/api/newRentals",
               method: "post",
               data: vm
           })
               .done(function () {
                   toastr.success("Rentals successfully recorded.");

                   $("#customer").typeahead("val", "");
                   $("#car").typeahead("val", "");
                   $("#cars").empty();

                   vm = { carIds: [] };

               })
               .fail(function () {
                   toastr.error("Something unexpected happened");
               });
           return false;
       }
   );
});