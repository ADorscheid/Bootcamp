# Get Hotel data from the server and print the hotels
import urllib.request
import json
baseUrl = "https://tehotelreservations.azurewebsites.net"
def main():
    url = baseUrl + "/hotels"
    webUrl = urllib.request.urlopen(url)

    if (webUrl.getcode() == 200):
        # Get the data
        hotelJson = webUrl.read()
        # print(hotelJson)
        printHotels(hotelJson)
    else: 
        print("There was an error!")


def printHotels(theJson):
    hotels = json.loads(theJson)
    for hotel in hotels:
        print("---------------------------------------------------------------")
        print(hotel["name"] + ", " + hotel["address"]["city"] + ", " + hotel["address"]["state"])
        getReservations(hotel["id"])

def getReservations(hotelId):
    url = baseUrl + "/hotels/" + str(hotelId) + "/reservations"
    webUrl = urllib.request.urlopen(url)

    if (webUrl.getcode() == 200):
        # Get the data
        resJson = webUrl.read()
        # print(hotelJson)
        printReservations(resJson)
    else: 
        print("There was an error!")


def printReservations(theJson):
    reservations = json.loads(theJson)
    for res in reservations:
        print("\t" + str(res["id"]) + "  " + res["fullName"] + "  " + str(res["guests"]) + " guests")


if __name__ == "__main__":
    main()

