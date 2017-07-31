/* Polish translation for the jQuery Timepicker Addon */
/* Written by Michał Pena */
/* Overwritten by Bartłomiej Bieńczyk - added months/days*/
(function($) {
    $.timepicker.regional['pl'] = {
        monthNames: ['Styczeń', 'Luty', 'Marzec', 'Kwiecień', 'Maj', 'Czerwiec', 'Lipiec', 'Sierpień', 'Wrzesień', 'Październik', 'Listopad', 'Grudzień'],
        dayNames: ['Poniedziałek', 'Wtorek', 'Środa', 'Czwartek', 'Piątek', 'Sobota', 'Niedziela'],
        dayNamesShort: ['Pon', 'Wt', 'Śr', 'Czw', 'Pt', 'Sob', 'Nd'],
        dayNamesMin: ['Pon', 'Wt', 'Śr', 'Czw', 'Pt', 'Sob', 'Nd'],
		timeOnlyTitle: 'Wybierz godzinę',
		timeText: 'Czas',
		hourText: 'Godzina',
		minuteText: 'Minuta',
		secondText: 'Sekunda',
		millisecText: 'Milisekunda',
		microsecText: 'Mikrosekunda',
		timezoneText: 'Strefa czasowa',
		currentText: 'Teraz',
		closeText: 'Gotowe',
		timeFormat: 'HH:mm',
		timeSuffix: '',
		amNames: ['AM', 'A'],
		pmNames: ['PM', 'P'],
		isRTL: false
	};
	$.timepicker.setDefaults($.timepicker.regional['pl']);
})(jQuery);
