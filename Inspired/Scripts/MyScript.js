var ospry = new Ospry('pk-test-mm3nyd399te4tplr3ewv29n3');




$(document).ready(function () {

    $('#up-form').submit(function (e) {
        e.preventDefault();
        ospry.up({
            form: this,
            imageReady: function (err, metadata, i) {
                if (err === null) {
                    console.log('Image uploaded to: ' + metadata.url);
                    var picurl = metadata.url;
                    $("#target-pic").text(picurl);
                }
            },
        });
    });


   $(function () {
       CKEDITOR.replace('editor',
        {
            customConfig: '/Scripts/ckeditor/config.js'
        });
   });


    $('.ui.accordion').accordion();

    $('#close_dialy_tip').on('click', function () {
        $(this).closest('#dialy_tip').transition('fade');
    })
    ;

    $('#close_missing_cat').on('click', function () {
        $(this).closest('#missing_cat_row').transition('fade');
    })
    ;


    $(function () {
        $("#service-dropdown").dropdown({
            allowLabels: true
        });
        $("#service-dropdown2").dropdown({
            allowLabels: true
        });
    });

    $('.ui.checkbox')
  .checkbox()
    ;

    $('.coupled.modal')
  .modal({
      allowMultiple: true
  })
    ;

    $('#coat')
    .popup({
        inline: true,
        hoverable: true,
        position: 'top left',
        delay: {
            show: 300,
            hide: 200
        }
    })
    ;

    $('.special.cards .image').dimmer({
        on: 'hover'
    });

    $('.ui.sticky')
      .sticky({
          context: '#example1'
      });
    $('.pointing.menu .item').tab();

    $('#reset_adoption').click(function () {
        $('#adoption_form').trigger('reset');
    });

    $('#click1').click(function () {
        $('.shape').shape('flip back');
    });

    $('.ui.sidebar').sidebar({
    });


    $('.special.cards .image').dimmer({
        on: 'hover'
    });



    $("#switch_sidebar").click(function () {
        var padding = $('#my_content').css('padding-left');
        var newPadding = (padding == '260px') ? '1em' : '260px';
        $('#my_content').css('padding-left', newPadding);
    });


    $("#call_adopt_modal").click(function () {
        $('#adopt_modal')
            .modal('show')
              .modal('setting', 'transition', 'scale');
    });



    $("#call_cat_profile_modal").click(function () {
        $('#cat_profile_modal')
            .modal('show')
            .modal({
                blurring: true
            })
              .modal('setting', 'transition', 'fade up');
    });

    $("#coat").click(function () {
        $('#coat_modal')

              .modal('setting', 'transition', 'fade up');

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




$(function () {
    $(":file").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = imageIsLoaded;
            reader.readAsDataURL(this.files[0]);
        }
    });
});

function imageIsLoaded(e) {
    $('#myCat').attr('src', e.target.result);
};