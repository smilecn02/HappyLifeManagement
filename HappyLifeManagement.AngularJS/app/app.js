'use strict';

var app = angular.module('myApp',
    [
        'ngSanitize',
        'ngRoute',
        'ui.bootstrap',
        'bw.paging',
        'chieffancypants.loadingBar', 'ngAnimate'
    ]);

app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "app/note/note.view.html",
        controller: "NoteController"
    })
    .when("/paging", {
        templateUrl: "app/paging/paging.view.html",
        controller: "PaginationDemoCtrl"
    })
    .when("/loading-bar", {
        templateUrl: "app/loading-bar/loading-bar.view.html"
    })
    .when("/about", {
        templateUrl: "app/about/about.view.html"
    });
});



