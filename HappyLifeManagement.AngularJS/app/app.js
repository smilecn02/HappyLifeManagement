'use strict';

//var app = angular.module("myApp", ['ngSanitize', '$http']);

var app = angular.module('myApp', ['ngSanitize', 'ngRoute']);


app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "app/note/note.view.html",
        controller: "NoteController"
    })
    .when("/red", {
        templateUrl: "red.htm"
    })
    .when("/green", {
        templateUrl: "green.htm"
    })
    .when("/blue", {
        templateUrl: "blue.htm"
    });
});



