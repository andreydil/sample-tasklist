(function() {
    'use strict';

    var app = angular.module('app');

    app.constant('routes', [
        {
            url: '/',
            config: {
                templateUrl: 'Angular1SPA/projects/projects.html',
                title: 'Task List',
                settings: {}
            }
        },
        {
            url: '/addProject',
            config: {
                templateUrl: 'Angular1SPA/projects/addProject.html',
                title: 'Add New Project',
                settings: {}
            }
        },
        {
            url: '/editProject/:id',
            config: {
                templateUrl: 'Angular1SPA/projects/editProject.html',
                title: 'Edit Project',
                settings: {}
            }
        }
    ]);

    app.config(['$routeProvider', 'routes', routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function(r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

})();