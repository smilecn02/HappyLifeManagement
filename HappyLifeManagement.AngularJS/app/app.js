'use strict';

var app = angular.module('myApp',
    [
        'ngSanitize',
        'ngRoute',
        'ui.bootstrap',
        'bw.paging',
        'chieffancypants.loadingBar', 'ngAnimate',
        'ngDialog',
        'blockUI'
    ]);

app.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = false;
}]);

app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "app/note/note.view.html",
        controller: "NoteController"
    })
    .when("/about", {
        templateUrl: "app/about/about.view.html"
    });
});



