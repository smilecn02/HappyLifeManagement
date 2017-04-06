'use strict';

//var app = angular.module("myApp", ['ngSanitize', '$http']);

var app = angular.module('myApp', ['ngSanitize', 'ngRoute', 'ui.bootstrap', 'bw.paging']);


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
    .when("/green", {
        templateUrl: "green.htm"
    })
    .when("/blue", {
        templateUrl: "blue.htm"
    });
});



