jQuery.noConflict();

/* Plugin to make variable height divs equal heights */
jQuery.fn.sameHeights = function () {

    var tallest = 0;
    this.children().each(function () {
        if (jQuery(this).outerHeight() > tallest) {
            tallest = jQuery(this).outerHeight();
        }
    });
    jQuery(this).children().height(tallest);
};

/*---------------------------Pretty Photo--------------------------------*/
jQuery(function () {
    jQuery("a[rel^='prettyPhoto']").prettyPhoto({
        animation_speed: 'fast',
        slideshow: 5000,
        autoplay_slideshow: false,
        opacity: 0.80,
        show_title: false,
        allow_resize: true,
        default_width: 800,
        default_height: 600,
        counter_separator_label: '/',
        theme: 'pp_default',
        horizontal_padding: 20,
        hideflash: false,
        wmode: 'opaque',
        autoplay: true,
        modal: false,
        deeplinking: false,
        overlay_gallery: true,
        keyboard_shortcuts: true,
        changepicturecallback: function () { },
        callback: function () { },
        ie6_fallback: true
    });
});
/*------------------------Sortable Gallery Hover---------------------------*/
function hover_overlay() {

    jQuery('.hover img.alignleft, .hover img.alignright').hover(function () {
        jQuery(this).stop().animate({ opacity: 0.7 }, 500);
    }, function () {
        jQuery(this).stop().animate({ opacity: 1 }, 500);
    });

    jQuery('.hover img').hover(function () {
        jQuery(this).stop().animate({ opacity: 0.7 }, 500);
    }, function () {
        jQuery(this).stop().animate({ opacity: 1 }, 500);
    });

}

/*********** Scroll to Top ************/
jQuery(function () {
    /*jQuery(window).scroll(function() {
		if(jQuery(this).scrollTop() != 0) {
			jQuery('#toTop').fadeIn();	
		} else {
			jQuery('#toTop').fadeOut();
		}
	});*/
    jQuery('.toTop').click(function () {
        jQuery('body,html').animate({ scrollTop: 0 }, 800);
    });
});
/**************************************/


/************ Box Grids ***************/

jQuery(document).ready(function () {
    //jQuery('.flickr_badge_image:nth-child(3)').css({ marginRight: '0px' });
    jQuery('.footer .grid_4').sameHeights();
    jQuery('.tagcloud').append('<div class="clear"></div>');
    hover_overlay();


    // Toggles
    jQuery(".toggle-container").hide();
    jQuery(".toggle-trigger").click(function (e) {
        e.preventDefault;
        jQuery(this).toggleClass("active").next().slideToggle(100);
        return false;
    });

    //Tooltips
    jQuery(".tip_trigger").hover(function () {
        tip = jQuery(this).find('.tip');
        tip.show(); //Show tooltip
    }, function () {
        tip.hide(); //Hide tooltip
    }).mousemove(function (e) {
        var mousex = e.pageX + 20; //Get X coodrinates
        var mousey = e.pageY + 20; //Get Y coordinates
        var tipWidth = tip.width(); //Find width of tooltip
        var tipHeight = tip.height(); //Find height of tooltip

        //Distance of element from the right edge of viewport
        var tipVisX = jQuery(window).width() - (mousex + tipWidth);
        //Distance of element from the bottom of viewport
        var tipVisY = jQuery(window).height() - (mousey + tipHeight);

        //Absolute position the tooltip according to mouse position
        tip.css({ top: mousey, left: mousex });
    });
    //To switch directions up/down and left/right just place a "-" in front of the top/left attribute
    //Vertical Sliding
    jQuery('.boxgrid.slidedown').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '-260px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 600 });
    });
    //Horizontal Sliding
    jQuery('.boxgrid.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '325px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 600 });
    });
    //Diagnal Sliding
    jQuery('.boxgrid.thecombo').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '260px', left: '325px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px', left: '0px' }, { queue: false, duration: 600 });
    });
    //Partial Sliding (Only show some of background)
    jQuery('.boxgrid.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '90px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 600 });
    });
    //Full Caption Sliding (Hidden to Visible)
    jQuery('.boxgrid.captionfull').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '200px' }, { queue: false, duration: 300 });
    });
    //Caption Sliding (Partially Hidden to Visible)
    jQuery('.boxgrid.caption').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '160px' }, { queue: false, duration: 300 });
    });
    //Small Horizontal Sliding
    jQuery('.boxsmgrid.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 400 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 500 });
    });
    //Small Partial Sliding (Only show some of background)
    jQuery('.boxsmgrid.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 300 });
    });


    jQuery('.boxgrid400.slidedown').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '-260px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 600 });
    });
    //Horizontal Sliding
    jQuery('.boxgrid400.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '325px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 600 });
    });
    //Diagnal Sliding
    jQuery('.boxgrid400.thecombo').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '260px', left: '325px' }, { queue: false, duration: 600 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px', left: '0px' }, { queue: false, duration: 600 });
    });
    //Partial Sliding (Only show some of background)
    jQuery('.boxgrid400.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '140px' }, { queue: false, duration: 400 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 400 });
    });
    //Full Caption Sliding (Hidden to Visible)
    jQuery('.boxgrid.captionfull').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '200px' }, { queue: false, duration: 300 });
    });
    //Caption Sliding (Partially Hidden to Visible)
    jQuery('.boxgrid.caption').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '160px' }, { queue: false, duration: 300 });
    });
    //Small Horizontal Sliding
    jQuery('.boxsmgrid.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 400 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 500 });
    });
    //Small Partial Sliding (Only show some of background)
    jQuery('.boxsmgrid.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 300 });
    });

    jQuery('.boxgrid300.slidedown').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '-260px' }, { queue: false, duration: 500 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 500 });
    });
    //Horizontal Sliding
    jQuery('.boxgrid300.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '325px' }, { queue: false, duration: 500 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 500 });
    });
    //Diagnal Sliding
    jQuery('.boxgrid300.thecombo').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '260px', left: '325px' }, { queue: false, duration: 500 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px', left: '0px' }, { queue: false, duration: 500 });
    });
    //Partial Sliding (Only show some of background)
    jQuery('.boxgrid300.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '90px' }, { queue: false, duration: 500 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '0px' }, { queue: false, duration: 500 });
    });
    //Full Caption Sliding (Hidden to Visible)
    jQuery('.boxgrid300.captionfull').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '200px' }, { queue: false, duration: 300 });
    });
    //Caption Sliding (Partially Hidden to Visible)
    jQuery('.boxgrid300.caption').hover(function () {
        jQuery(".cover", this).stop().animate({ top: '120px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ top: '160px' }, { queue: false, duration: 300 });
    });
    //Small Horizontal Sliding
    jQuery('.boxsmgrid.slideright').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 400 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 500 });
    });
    //Small Partial Sliding (Only show some of background)
    jQuery('.boxsmgrid.peek').hover(function () {
        jQuery(".cover", this).stop().animate({ left: '70px' }, { queue: false, duration: 300 });
    }, function () {
        jQuery(".cover", this).stop().animate({ left: '0px' }, { queue: false, duration: 300 });
    });

    jQuery(".reply a").addClass('button normal small');
    jQuery(".avatar").addClass('frame');
    jQuery(".post-tags a").addClass('button tag');
    jQuery('#testimonials .slide');
    setInterval(function () {
        jQuery('#testimonials .slide').filter(':visible').fadeOut(2000, function () {
            if (jQuery(this).next().size()) {
                jQuery(this).next().fadeIn(1000);
            }
            else {
                jQuery('#testimonials .slide').eq(0).fadeIn(1000);
            }
        });
    }, 6000);

    jQuery('.sf-menu li li').has('ul').addClass('icon');

});

jQuery(function () {
    jQuery("ul.tabs").tabs("div.panes > div", { effect: 'fade' });
});

/********* Contact Widget *************/
function checkemail(emailaddress) {
    var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
    return pattern.test(emailaddress);
}

jQuery(document).ready(function () {
    jQuery('#registerErrors, .widgetinfo').hide();
    jQuery('#contactFormWidget input#wformsend').click(function () {
        var $name = jQuery('#wname').val();
        var $email = jQuery('#wemail').val();
        var $message = jQuery('#wmessage').val();
        var $subject = jQuery('#wsubject').val();
        var $contactemail = jQuery('#wcontactemail').val();
        var $contacturl = jQuery('#wcontacturl').val();
        var $mywebsite = jQuery('#wcontactwebsite').val();

        if ($name != '' && $name.length < 3) { $nameshort = true; } else { $nameshort = false; }
        if ($name != '' && $name.length > 30) { $namelong = true; } else { $namelong = false; }
        if ($email != '' && checkemail($email)) { $emailerror = true; } else { $emailerror = false; }
        if ($message != '' && $message.length < 3) { $messageshort = true; } else { $messageshort = false; }

        jQuery('#contactFormWidget .loading').animate({ opacity: 1 }, 250);

        if ($name != '' && $nameshort != true && $namelong != true && $email != '' && $emailerror != false && $message != '' && $messageshort != true && $contactemail != '' && $contacturl != '' && $mywebsite != '') {
            jQuery.post($contacturl,
				{ type: 'widget', contactemail: $contactemail, name: $name, email: $email, message: $message, subject: $subject },
				function (data) {
				    jQuery('#contactFormWidget .loading').animate({ opacity: 0 }, 250);
				    jQuery('.form').fadeOut();
				    jQuery('#bottom #wname, #bottom #wemail, #bottom #wmessage').css({ 'border': '0' });
				    jQuery('.widgeterror').hide();
				    jQuery('.widgetinfo').fadeIn('slow');
				    jQuery('.widgetinfo').delay(2000).fadeOut(1000, function () {
				        jQuery('#wname, #wemail, #wmessage, #wsubject').val('');
				        jQuery('.form').fadeIn('slow');
				    });
				}
			);

            return false;
        } else {
            jQuery('#contactFormWidget .loading').animate({ opacity: 0 }, 250);
            jQuery('.widgeterror').hide();
            jQuery('.widgeterror').fadeIn('fast');
            jQuery('.widgeterror').delay(3000).fadeOut(1000);

            if ($name == '' || $nameshort == true || $namelong == true) {
                jQuery('#wname').css({ 'border': '1px solid #941e1c' });
            } else {
                jQuery('#wname').css({ 'border': '1px solid #787878' });
            }

            if ($email == '' || $emailerror == false) {
                jQuery('#wemail').css({ 'border': '1px solid #941e1c' });
            } else {
                jQuery('#wemail').css({ 'border': '1px solid #787878' });
            }

            if ($message == '' || $messageshort == true) {
                jQuery('#wmessage').css({ 'border': '1px solid #941e1c' });
            } else {
                jQuery('#wmessage').css({ 'border': '1px solid #787878' });
            }

            return false;
        }
    });
});

// jQuery Input Hints plugin
// Copyright (c) 2009 Rob Volk
// http://www.robvolk.com
jQuery.fn.inputHints = function () {
    jQuery(this).each(function (i) { jQuery(this).val(jQuery(this).attr('title')); }); jQuery(this).focus(function () {
        if (jQuery(this).val() == jQuery(this).attr('title'))
            jQuery(this).val('');
    }).blur(function () {
        if (jQuery(this).val() == '')
            jQuery(this).val(jQuery(this).attr('title'));
    });
};


jQuery(document).ready(function () {
    jQuery('input[title], textarea[title]').inputHints();
    jQuery('.socialbar a').click(function () {
        window.open(this.href);
        return false;
    });
});
/**************************************/

