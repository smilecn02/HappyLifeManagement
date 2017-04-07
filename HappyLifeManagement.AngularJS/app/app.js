'use strict';

var app = angular.module('myApp',
    [
        'ngSanitize',
        'ngRoute',
        'ui.bootstrap',
        'bw.paging',
        'chieffancypants.loadingBar', 'ngAnimate',
        'ngDialog'
    ]);

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



