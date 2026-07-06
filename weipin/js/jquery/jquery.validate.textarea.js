jQuery.fn.checkLength=function(parameters){defaults={min:0,max:5}
jQuery.extend(defaults,parameters);var taValue=$(this).val();var len=taValue.length;if(len>=defaults.max){return false;}else if(len<=defaults.min){return false;}else{return true;}
}