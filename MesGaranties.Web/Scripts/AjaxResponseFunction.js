//reponse success truc
var nbComsParChargementAjax = 10;
function successAddComm() {
    $("#formulaireCommentaire42xB").fadeOut(900);
    var commentaire = $('#supercompliquepourmettrenotrecom').html();
    $('#supercompliquepourmettrenotrecom').html("");
     $("#supercompliquepourmettrenotrecom").after(commentaire);
    $(".toremoveonpost").remove();
    $('#addOneMoreComment').click(function() {
        $("#formulaireCommentaire42xB").fadeIn(400);
        $("#boutonajoutcom").removeAttr("disabled");
        $('#addOneMoreComment').fadeOut(300);
        $('#Texte').val("");
        document.getElementById("Texte").focus();
    });
    $(".commentaireDeComExt").first().fadeOut(0);
    $(".commentaireDeComExt").first().fadeIn(900);
    $('#addOneMoreComment').fadeIn(900);
    if ($(".commentaireDeComExt").length >= nbComsParChargementAjax)
        $(".commentaireDeComExt").last().remove();
}

function changeIdForMoreCom() {
    $("#morecomments").attr("class", "");
    var divtoShow = $("#morecomments");
    divtoShow.attr("id", "morecommentsold");
    divtoShow.hide(0);
    divtoShow.fadeIn(900);
}

function comToValid(value) {
    if (value > 0) {
        $("#box_" + value).children("input").attr("checked", "checked");
        $("#span_" + value).remove();
    } else {
        alert("une erreur est survenue :(");
    }

}

function errorAjax() {
    alert("Une erreur est aparu!");
}

function onStartDisableComment() {
    $("#boutonajoutcom").attr("disabled", "disabled");
}
function onStartDisableNewsLetter() {
    $("#NewsLetterButon").attr("disabled", "disabled");
}
function onStartHideShowMore() {
    $(".PagedList-skipToNext").hide(0);
}
