$(document).ready(function () {
    loadAllDVDs();
    $('#add-form').hide();
    $('#edit-form').hide();
    $('#displayDetail').hide();
});


function loadAllDVDs() {
    clearDVDDisplay();
    
    $('#main-page-error-messages').empty();
    
    var DVDdisplaytable = $('#contentRows');
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvds',
        // url: 'https://tsg-dvds.herokuapp.com/dvds',
        success: function (data) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.directorName;
                var rating = dvd.rating.ratingName;
                var notes = dvd.notes;
                var id = dvd.dvdId;

                var row = '<tr>';
                row += '<td><a href="#" onclick="displayDVD(' + id + ')">' + '<u>' + title + '</u>' + '</a></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="getDVDToEdit(' + id + ')"> <u> Edit</u> </a>' + " | " + '<a href="#" onclick="deleteDVD(' + id + ')"> <u> Delete</u></a></td>';
                row += '</tr>';

                DVDdisplaytable.append(row);

            })
        },
        error: function () {
            $('#main-page-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });
}


function displayDVD(id) {

    $('#display-detail-error-messages').empty();

    $('#mainPage').hide();
    $('#displayDetail').show();

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvds/' + id,
        //url: 'https://tsg-dvds.herokuapp.com/dvd/' + id,
        success: function (data, status) {
            $('#displayTitle').text(data.title);
            $('#displayYear').text(data.releaseYear);
            $('#displayDirector').text(data.directorName);
            $('#displayRating').text(data.rating.ratingName);
            $('#displayNotes').text(data.notes);
        },
        error: function () {
            $('#display-detail-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
        }
    });
}


$('#displayBack').click(function () {

    $('#mainPage').show();
    $('#displayDetail').hide();
});



$('#create-dvd-button').on('click', function () {

    $('#add-form').show();
    $('#add-form')[0].reset();
    $('#mainPage').hide();
});


$('#add-button').on('click', function () {

    var year = $('#add-release-year').val();

    if (year.length != 4 || isNaN(year) == true) {

        $('#create-dvd-error-messages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a 4-digit year.'));

        return false;
    }

    var title = $('#add-title').val();

    if (title == '' || title === null) {
        $('#create-dvd-error-messages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('A title field is required.'));

        return false;

    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44329/dvds',
        //url: 'https://tsg-dvds.herokuapp.com/dvd',
        data: JSON.stringify({
            title: $('#add-title').val(),
            releaseYear: $('#add-release-year').val(),
            directorName: $('#add-director').val(),
            ratingId: $('#add-rating').val(),
            notes: $('#add-notes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            $('#create-dvd-error-messages').empty();
            loadAllDVDs();
            $('#mainPage').show();
            $('#add-form').hide();
        },
        error: function () {
            loadAllDVDs();
            $('#create-dvd-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));

        }
    });

});

$('#cancel-add-button').on('click', function () {
    $('#create-dvd-error-messages').empty();
    loadAllDVDs();
    $('#mainPage').show();
    $('#add-form').hide();
});


function getDVDToEdit(id) {

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvds/' + id,
        //url: 'https://tsg-dvds.herokuapp.com/dvd/' + id,
        success: function (data, status) {
            var headerTitle = data.title;
            $('#edit-title').val(data.title);
            $('#edit-release-year').val(data.releaseYear);
            $('#edit-director').val(data.directorName);
            $('#edit-rating').val(data.ratingId);
            $('#edit-notes').val(data.notes);
            $('#edit-dvdid').val(data.id);
            $('h2').text('Edit Dvd: ' + headerTitle);

           
            $('#edit-form').show();
            $('#mainPage').hide();
            $('#save-changes-button').attr('onclick', 'savechanges(' + id + ')');
            
        },
        error: function () {
            $('#main-page-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });    

}


function savechanges(id) {
   
    if ($('#edit-release-year').val() <= 1970 || $('#edit-release-year').val() >= 2021 || isNaN($('#edit-release-year').val()) == true) {

            $('#edit-dvd-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Please enter a valid 4-digit year.'));

            return false;
        }

        var title = $('#edit-title').val();

        if (title == '' || title == null) {
            $('#edit-dvd-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('A title field is required.'));

            return false;

        }

        $.ajax({
            async: true,
            crossDomain: true,
            type: 'PUT',
            url: 'https://localhost:44329/dvds/' + id,
            //url: 'https://tsg-dvds.herokuapp.com/dvd/' + $('#edit-dvdid').val(),
            dataType: 'json',
            processData: false,
            data: JSON.stringify({

                title: $('#edit-title').val(),
                releaseYear: $('#edit-release-year').val(),
                directorName: $('#edit-director').val(),
                ratingId: $('#edit-rating').val(),
                notes: $('#edit-notes').val()

            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'success': function () {

                clearDVDDisplay();
                loadAllDVDs();
                $('#mainPage').show();
                $('#edit-form').hide();

            },
            'error': function () {
                loadAllDVDs();
                $('#edit-dvd-error-messages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        });
}



$('#cancel-edit-button').on('click', function () {
    $('#edit-dvd-error-messages').empty();
    loadAllDVDs();
    $('#mainPage').show();
    $('#edit-form').hide();
});


function deleteDVD(id) {

    var confirm = window.confirm("Are you sure you want to delete this Dvd from your collection?");
    if (confirm == true) {
        $.ajax({
            type: 'DELETE',
            url: 'https://localhost:44329/dvds/' + id,
            //url: 'https://tsg-dvds.herokuapp.com/dvd/' + id,
            success: function (status) {
                loadAllDVDs();
            }
        });

    } else {
        loadAllDVDs();
    }
}


$("#search-button").click(function (event) {

    if ($('#search-term').val() == "" || $('#search-category').val() == "") {

        $('#main-page-error-messages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Both search dropdown and search text box are required.'));

        return false;
    }

    clearDVDDisplay();
    var contentRows = $('#contentRows');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvds/' + $('#search-category').val() + "/" + $('#search-term').val(),
        //url: 'https://tsg-dvds.herokuapp.com/dvds/' + $('#search-category').val() + "/" + $('#search-term').val(),
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var date = dvd.releaseYear;
                var dir = dvd.directorName;
                var rate = dvd.rating.ratingName;
                var id = dvd.dvdid;

                var row = '<tr>';
                row += '<td><a href="#" onclick="displayDVD(' + id + ')">' + '<u>' + title + '</u>' + '</a></td>';
                row += '<td>' + date + '</td>';
                row += '<td>' + dir + '</td>';
                row += '<td>' + rate + '</td>';
                row += '<td><a href="#" onclick="getDVDToEdit(' + id + ')"> <u> Edit</u> </a>' + " | " + '<a href="#" onclick="deleteDVD(' + id + ')"> <u> Delete</u></a></td>';
                row += '</tr>';

                contentRows.append(row);
                
                $('#search-term').val("");
            })
        },
        error: function () {
            $('#main-page-error-messages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('No Dvds were found with search term ' + $('#search-term').val()));

        }
    })
});


function clearDVDDisplay() {
    $('#contentRows').empty();
}




