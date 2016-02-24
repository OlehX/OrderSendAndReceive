(function () {
    'use strict';

    angular
        .module('app')
        .factory('orderClientSvc', function ($resource) {
            return $resource("api/order/",
                {
                    'query': {
                        method: 'POST',
                        url: '/api/order',
                        data: response 

                    }
                });
        });
})();
