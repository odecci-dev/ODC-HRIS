let toggleButton = window.localStorage.getItem("toggleButton");
let toggle = document.querySelector("#toggleButton");


document.getElementById('toggle-sidebar').addEventListener('click', () => {
    let isActive = localStorage.getItem('sidebar-active') === 'true';
    localStorage.setItem('sidebar-active', !isActive);
 
    updateSidebar();
});
function updateSidebar() {
    const isActive = localStorage.getItem('sidebar-active') === 'true';
    const sidebar = document.getElementById('mysidebar');
    const subnav = document.getElementById('subnav');
    const dashboaradsidebar = document.getElementById('dashboard-main-container') == null ? document.getElementById('emp-main-container') : document.getElementById('dashboard-main-container');
    //const empdashboard = document.getElementById('emp-main-container');
    console.log(dashboaradsidebar);
    if (isActive) {
        sidebar.classList.add('active');
        //subnav.classList.add('active');
        dashboaradsidebar.classList.add('active');
        //empdashboard.classList.add('active');
        console.log(localStorage.getItem('sidebar-active'));
    } else {
        sidebar.classList.remove('active');
        //subnav.classList.remove('active');
        dashboaradsidebar.classList.remove('active');
        //empdashboard.classList.remove('active');
}
} function showloadingoverlay() {
    const loadingOverlay = document.getElementById('loadingOverlay');
    loadingOverlay.style.display = 'flex'; // Display the loading overlay
}
function hideloadingoverlay() {
    loadingOverlay.style.display = 'none';
}

document.addEventListener('DOMContentLoaded', updateSidebar);

function notifyMsg(title, msg, color, icon) {
    iziToast.show({
        title: title,
        message: msg,
        theme: "light",
        color: color,
        icon: icon,
        transitionIn: "bounceInDown",
        transitionOut: "flipOutX",
        position: "topCenter",
    });
}

async function fetchpositionselect() {

 
    $.ajax({
        url: '/Position/GetPositionSelect',
        data: {
        },
        type: "GET",
        datatype: "json",
        success: function (data) {
            console.log(data)
            $("#position").empty();
            $("#position").append('<option value="" disabled selected>Select Position</option>');
            for (var i = 0; i < data.length; i++) {
                $("#position").append('<option value="' + data[i].id + '">' + data[i].name + "</option>");
            }

        }
    });
}

function fetchdepartmentselect() {
 
    const data = { Position: '', page: 1 };
    $.ajax({
        url: '/Department/GetDepartmentList',
        data: {
            data: data,
        },
        type: "POST",
        datatype: "json",
        success: function (data) {
            //console.log(data)
            $("#department").empty();
            $("#department").append('<option value="0" disabled selected>-Select Department-</option>');
            for (var i = 0; i < data[0].items.length; i++) {
                $("#department").append('<option value="' + data[0].items[i].id + '">' + data[0].items[i].departmentName + "</option>");
            }

        }
    });
}
function fetchusertypeselect() {
 
    $.ajax({
        url: '/UserType/GetUserTypeList',
        data: {
        },
        type: "GET",
        datatype: "json",
        success: function (data) {
            console.log(data)
            $("#emptype").empty();
            $("#emptype").append('<option value="" disabled selected>Select Employee Type</option>');
            for (var i = 0; i < data.length; i++) {
                $("#emptype").append('<option value="' + data[i].id + '">' + data[i].userType + "</option>");
            }

        }
    });
}
function fetchpayrolltypeselect() {
  
    $.ajax({
        url: '/Payroll/GetPayrollType',
        data: {},
        type: "GET",
        datatype: "json"
    }).done(function (data) { // @* //  *@
        console.log(data)
        $("#payrolltype").empty();
        $("#payrolltype").append('<option value="" disabled selected>Select Payroll Type</option>');
        for (var i = 0; i < data.length; i++) {
            $("#payrolltype").append('<option value="' + data[i].id + '">' + data[i].payrollType + "</option>");
        }
    });
}

function fetchsalarytypeselect() {

    $.ajax({
        url: '/Salary/GetSalaryType',
        data: {},
        type: "GET",
        datatype: "json"
    }).done(function (data) { // @* //  *@
        console.log(data)
        $('#rate').val(data[0].rate);
        $("#salarytype").empty();
        $("#salarytype").append('<option value="" disabled selected>Select Salary Type</option>');
        for (var i = 0; i < data.length; i++) {
            $("#salarytype").append('<option value="' + data[i].id + '">' + data[i].salaryType + "</option>");
        }
    });
}
function fetchstatusselect() {

    $.ajax({
        url: '/Employee/GetStatusType',
        data: {},
        type: "GET",
        datatype: "json"
    }).done(function (data) { // @* //  *@
        console.log(data)
        $("#status").empty();
        $("#status").append('<option value="" disabled selected>Select Status</option>');
        for (var i = 0; i < data.length; i++) {
            $("#status").append('<option value="' + data[i].id + '">' + data[i].status + "</option>");
        }
    });
}
function fetchtaskselect() {

    $.ajax({
        url: '/Task/GetTaskList',
        data: {},
        type: "GET",
        datatype: "json"
    }).done(function (data) { // @* //  *@
        console.log(data)
        $("#task").empty();
        $("#task").append('<option value="" disabled selected>Select Task</option>');
        for (var i = 0; i < data.length; i++) {
            $("#task").append('<option value="' + data[i].id + '">' + data[i].title + "</option>");
        }
    });
}
function printPage() {
    var printWindow = window.open('/Home/OR_Print', '_blank');
    // Wait for the new window to load and then trigger the print dialog
    $('#modal-success').modal('show');
    $('#defaultmodal').modal('hide');
    printWindow.onload = function () {
        printWindow.print();

    };

}

function print_or() {
    fetch(`/Home/OR_Print`) // Adjust URL to your endpoint
        .then(response => response.text())
        .then(html => {
            document.querySelector('#modal-xl .modal-body-2').innerHTML = html;
            $('#modal-xl').modal('show'); // Show the modal using Bootstrap
        })
        .catch(error => console.error('Error loading content:', error));

    //$('#modal-success').modal('show');
}
function printDiv(divId) {

    $('#defaultmodal').modal('hide');
    var iframe = document.createElement('iframe');
    iframe.style.position = 'absolute';
    iframe.style.width = '0';
    iframe.style.height = '0';
    iframe.style.border = 'none';

    document.body.appendChild(iframe);

    var doc = iframe.contentWindow.document;
    doc.open();
    doc.write('<html><head><title>Print</title>');
    doc.write('<style>body{font-family: Arial, sans-serif;}</style>');
    doc.write('</head><body>');
    doc.write(document.getElementById(divId).innerHTML);
    doc.write('</body></html>');
    doc.close();

    iframe.contentWindow.focus();
    iframe.contentWindow.print();

    document.body.removeChild(iframe);
    $('#modal-success').modal('show'); c
}
function loadModal(url, modal, title, size, isToggled) {


    $(modal + ' .overlay').removeClass('d-none');
    $(modal + ' .modal-dialog').removeClass('modal-sm');
    $(modal + ' .modal-dialog').removeClass('modal-md');
    $(modal + ' .modal-dialog').removeClass('modal-lg');
    $(modal + ' .modal-dialog').removeClass('modal-xl');
    $(modal + ' .modal-dialog').removeClass('modal-fullscreen');
    $(modal + ' .modal-dialog').addClass('modal-' + size);
    $(modal + ' .modal-body').html('<div class="mt-5 mb-5"></div>');
    console.log(url);
    //if not toggle in button
    if (!isToggled)
        $(modal).modal('show');

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
         
            $(modal + ' .modal-body').html(res);
            $(modal + ' .modal-title').html(title);
            $(modal + ' .overlay').addClass('d-none');

            //load tooltip
            $('.modal [data-toggle="tooltip"]')
                .tooltip({ trigger: 'hover' });
        },
        error: function (result) {
            $(modal + ' .modal-body').html(`<p>${result.responseText}</p>`);
            if (result.status == 403 || result.status == 401)
                $(modal + ' .modal-body').html(`<p><b>Unauthorized!</b> Access to the requested resource is forbidden.</p>`);

            $(modal + ' .modal-title').html('Error Message');
            $(modal + ' .overlay').addClass('d-none');

        }
    });
};


document.addEventListener('DOMContentLoaded', function () {
});
