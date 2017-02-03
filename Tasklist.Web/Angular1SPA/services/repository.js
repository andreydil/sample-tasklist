(function () {
    'use strict';

    var serviceId = 'repository';
    angular.module('app').factory(serviceId, ['$http', 'common', datacontext]);

    function datacontext($http, common) {
        var $q = common.$q;

        var service = {
            getAllProjects: getAllProjects,
            addProject: addProject,
            getProjectById: getProjectById,
            editProject: editProject,
            deleteProject: deleteProject
        };

        return service;

        function getAllProjects() {
            return $http({
                method: 'GET',
                url: 'api/project',
                headers: {
                    'Content-type': 'application/json'
                }
            });
        }

        function addProject(name, description) {
            return $http({
                method: 'POST',
                url: 'api/project',
                headers: {
                    'Content-type': 'application/json'
                },
                data: {
                    name : name,
                    description: description
                }
            });
        }

        function getProjectById(id) {
            return $http({
                method: 'GET',
                url: 'api/project/' + id,
                headers: {
                    'Content-type': 'application/json'
                }
            });
        }

        function editProject(project) {
            return $http({
                method: 'PUT',
                url: 'api/project',
                headers: {
                    'Content-type': 'application/json'
                },
                data: project
            });
        }

        function deleteProject(id) {
            return $http({
                method: 'DELETE',
                url: 'api/project/' + id,
                headers: {
                    'Content-type': 'application/json'
                }
            });
        }
    }
})();