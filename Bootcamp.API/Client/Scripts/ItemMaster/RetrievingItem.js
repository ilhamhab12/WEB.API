$(document).ready(function () {
    LoadIndexItem();
    LoadSupplierCombo();
    LoadHiddenNotification();
    $('#table').DataTable({
        "ajax": LoadIndexItem()
    })
    ClearScreen();
})

function LoadIndexItem() {
    $.ajax({
        type: "GET",
        url: 'http://localhost:5672/api/Items/',
        async: false,
        datatype: "JSON",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                //menampilkan nomer
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Stock + '</td>';
                html += '<td>' + val.Suppliers.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadSupplierCombo() {
    $.ajax({
        url: 'http://localhost:5672/api/Suppliers',
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var supplier = $('#Suppliers');
            $.each(result, function (i, Suppliers) {
                $("<option></option>").val(Suppliers.Id).text(Suppliers.Name).appendTo(supplier);
            });
        }
    });
}

function Save() {
    var item = new Object();
    item.name = $('#Name').val();
    item.price = $('#Price').val();
    item.stock = $('#Stock').val();
    item.suppliers = $('#Suppliers').val();
    $.ajax({
        url: 'http://localhost:5672/api/Items/',
        type: 'POST',
        dataType: 'json',
        data: item,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been saved!",
                type: "success"
            },
            function () {
                window.location.href = '/Items/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function Edit() {
    var item = new Object();
    item.Id = $('#Id').val();
    item.Name = $('#Name').val();
    item.Price = $('#Price').val();
    item.Stock = $('#Stock').val();
    item.Suppliers = $('#Suppliers').val();
    $.ajax({
        url: 'http://localhost:5672/api/Items/' + item.Id,
        type: 'PUT',
        data: item,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Items/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Price').val('');
                $('#Stock').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: 'http://localhost:5672/api/Items/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Price').val(result.Price);
            $('#Stock').val(result.Stock);
            $('#Suppliers').val(result.Suppliers.Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:5672/api/Items/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Items/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#myModal').on('hidden.bs.modal', function () {
        $(this).find("input,textarea,select").val('').end();
        $('#Update').hide();
        $('#Save').show();
    });
};

function ValidationSave() {
    // asumsi semua text box valid
    var isAllValid = true

    //cek textbox name
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    // cek textbox price
    if ($('#Price').val() == "" || ($('#Price').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Price').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }
    
    // cek textbox stock
    if ($('#Stock').val() == "" || ($('#Stock').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Stock').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Stock').siblings('span.error').css('visibility', 'hidden');
    }
    
    // cek drop down supplier
    if ($('#Suppliers').val() == "Choose Supplier" || ($('#Suppliers').val() == "0")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Suppliers').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Suppliers').siblings('span.error').css('visibility', 'hidden');
    }

    //kalau semua fild terisi
    if (isAllValid) {
        Save();
    }
}

function ValidationEdit() {
    
    // asumsi semua text box valid
    var isAllValid = true

    //cek textbox name
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    // cek textbox price
    if ($('#Price').val() == "" || ($('#Price').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Price').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }

    // cek textbox stock
    if ($('#Stock').val() == "" || ($('#Stock').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Stock').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Stock').siblings('span.error').css('visibility', 'hidden');
    }

    // cek drop down supplier
    if ($('#Suppliers').val() == "Choose Supplier" || ($('#Suppliers').val() == 0) || ($('#Suppliers').val() == null)) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Suppliers').siblings('span.error').css('visibility', 'visible'); //notifikasi validasi muncul
    }
    else {
        $('#Suppliers').siblings('span.error').css('visibility', 'hidden');
    }

    //kalau semua fild terisi
    if (isAllValid) {
        Edit();
    }
}

//untuk menghide notifikasi validasi agar tidak muncul saat pertamakali di load
function LoadHiddenNotification() {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
        $('#Price').siblings('span.error').css('visibility', 'hidden');
        $('#Stock').siblings('span.error').css('visibility', 'hidden');
        $('#Suppliers').siblings('span.error').css('visibility', 'hidden');
        $('#Suppliers').val("Choose Supplier"); // agar pada saat create ke 2 supplier combo box tidak kosong
}
