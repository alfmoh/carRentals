$(document).ready(function () {
                var table = $("#cars").DataTable({
                    ajax: {
                        url: "/api/cars",
                        dataSrc: ""
                    },
                    columns: [
                        {
                            data: "name",
                            render: function (data, type, car) {
                                return "<a href='/cars/edit/" + car.id + "'>" + car.name + "</a>";
                            }
                        },
                        {
                            data: "carBrand.name"
                        },
                        {
                            data: "id",
                            render: function (data) {
                                return "<button class='btn-link js-deleteCar' data-car-id=" + data + ">Delete</button>";
                            }
                        }
                    ]
                });
                $("#cars").on("click", ".js-deleteCar", function () {
                    var button = $(this);
                    bootbox.confirm("Are you sure you want to delete this car?", function (result) {
                        if (result) {
                            $.ajax({
                                url: "/api/cars/" + button.attr("data-car-id"),
                                method: "DELETE",
                                success: function () {
                                    table.row(button.parents("tr")).remove().draw();
                                }
                            });
                        }
                    });
                });
            });