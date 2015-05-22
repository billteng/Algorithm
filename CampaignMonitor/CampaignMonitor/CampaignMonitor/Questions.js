// Requirement 5
String.prototype.startsWith = function (str) {
   return this.slice(0, str.length) == str;
};

String.prototype.endsWith = function (str) {
    return this.slice(-str.length) == str;
};

// Requirement 6
String.prototype.stripHtml = function () {
    return this.replace(/<\/?[^>]+>/gi, "");
};

// Requirement 7 & 8
// don't have more time to do, R7 is JQuery plugin
// R8 Ajax jsonp callback=?