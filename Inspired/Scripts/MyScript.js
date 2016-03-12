



$(document).ready(function () {
    $('.ui.accordion').accordion();

    $('#close_dialy_tip').on('click', function () {
        $(this).closest('#dialy_tip').transition('fade');
    })
    ;

    $('#close_missing_cat').on('click', function () {
      $(this).closest('#missing_cat_row').transition('fade');
  })
    ;

    $('.contropanel_menu').on('click', function () {
        $('.contropanel_menu').removeClass('active');
        $(this).addClass('active');
    });

    $(function () {
        $("#service-dropdown").dropdown({
            allowLabels: true
        });
    });


    $('.ui.sticky')
      .sticky({
          context: '#example1'
      });


    $('.ui.labeled.icon.sidebar')
      .sidebar('toggle')
    ;
    $('.pointing.menu .item').tab();

    

    $("#call_adopt_modal").click(function () {
        $('#adopt_modal').modal('show');
    });

    $("#confirm_adoption").click(function () {
        alertify.set('notifier', 'position', 'top-right');
        alertify.notify('You will get in touch soon', 'success', 5, function () { console.log('dismissed'); });
    });

});
///*ไดอารี่1*/
//$('#one').click(function () {
//    $("li").removeClass("active");
//    $("#di_statistic").AddClass("active");
//    $('#Di_detail').load("/ControlPanel/Diarypage  #stat");
//    $('.One-diary').toggle("fast");
//    $('.All-diary').toggle("fast");
//});




