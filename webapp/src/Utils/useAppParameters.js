function useAppParameters() {
    const apiBaseUrl = 'https://localhost:7052';

    const apiTourController = '/tour';
    const apiBookingController = '/booking';

    const apiTourUrl = apiBaseUrl + apiTourController;
    const apiBookingUrl = apiBaseUrl + apiBookingController;

    const getApiTourAllUrl = () => apiTourUrl + '/getall'
        , getApiTourPostUrl = () => apiTourUrl + '/add'
        , getApiTourGetUrl = (id) => apiTourUrl + '/get?id=' + id
        , getApiBookingAllUrl = () => apiBookingUrl + '/getall'
        , getApiBookingPostUrl = () => apiBookingUrl + '/add'
        , getApiBookingGetUrl = (id) => apiBookingUrl + '/get?id=' + id
        , getApiBookingRemoveUrl = (id) => apiBookingUrl + '/remove?id=' + id;

    const getAppTourGridNavigate = () => '/Tour'
        , getAppTourIdNavigate = (id) => '/Tour/' + id
        , getAppBookingGridNavigate = () => '/Booking'
        , getAppBookingIdNavigate = (id) => '/Booking/' + id
    

    return {
        getApiTourAllUrl
        , getApiTourPostUrl
        , getApiTourGetUrl
        , getApiBookingAllUrl
        , getApiBookingPostUrl
        , getApiBookingGetUrl
        , getApiBookingRemoveUrl
        , getAppTourGridNavigate
        , getAppTourIdNavigate
        , getAppBookingGridNavigate
        , getAppBookingIdNavigate
    }
}

export { useAppParameters };