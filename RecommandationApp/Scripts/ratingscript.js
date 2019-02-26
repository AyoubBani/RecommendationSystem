$(document).ready(function () {    

    // 0 

    var xstars = $('#stars li').parent().children('li.star');
    var defval = document.getElementById('ratingval');    
//    console.log('def val is ' + Math.round(defval.value));
    for (i = 0; i < Math.round(defval.value); i++) {
        $(xstars[i]).addClass('selected');
    }


    /* 1. Visualizing things on Hover - See next part for action on click */
    $('#stars li').on('mouseover', function () {
        
        var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on
        console.log("getting rating value is " + onStar);
        // Now highlight all the stars that's not after the current hovered star
        $(this).parent().children('li.star').each(function (e) {
            if (e < onStar) {
                $(this).addClass('hover');
            }
            else {
                $(this).removeClass('hover');
            }
        });

    }).on('mouseout', function () {
        $(this).parent().children('li.star').each(function (e) {
            $(this).removeClass('hover');
        });
    });


    /* 2. Action to perform on click */
    $('#stars li').on('click', function () {
        var onStar = parseInt($(this).data('value'), 10); // The star currently selected
        var stars = $(this).parent().children('li.star');

        for (i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }

        for (i = 0; i < onStar; i++) {
            $(stars[i]).addClass('selected');
        }

        // JUST RESPONSE (Not needed)
        var ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);
        var msg = "";
        if (ratingValue > 1) {
            msg = "Merci! Vous avez évalué " + ratingValue + " étoils.";
        }
        else {
            msg = "Nous allons nous améliorer. Vous avez noté ceci" + ratingValue + " étoils.";
        }
        responseMessage(msg);
        var id = document.getElementById('Offre_Id');
//        var id = h.value; //if you want to pass an Id parameter
//        window.location.href = '@Url.Action("Rate", "Offres")/' + id.value;
//        var url = "/Offres/Rate/" + id.value;
//        window.location.href = window.location.host+url;
//        window.location.href = '@Url.Action("Rate", "Offres")/' + id.value;
//        console.log("LOCATION: " + window.location.toString().substr(0,23));
        window.location.href = window.location.toString().substr(0, 23) + "Offres/Rate/" + id.value + "/" + ratingValue;
    });


});


function responseMessage(msg) {
    $('.success-box').fadeIn(200);
    $('.success-box div.text-message').html("<span>" + msg + "</span>");
}