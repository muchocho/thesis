import cv2
import RPi.GPIO as GPIO
import time
import serial
import mysql.connector
bottle_cascade = cv2.CascadeClassifier('cascade2.xml')
cap = cv2.VideoCapture(0)
myDb = mysql.connector.connect(
    host="localhost",
    user="root",
    passwd="root",
    database="bin_data")
GPIO.setmode(GPIO.BCM)
GPIO.setup(4, GPIO.OUT)
GPIO.setup(11, GPIO.OUT)
GPIO.setup(18, GPIO.OUT)
ser = serial.Serial('/dev/ttyACM0', baudrate=9600)


while(True):


    while(True):
        deco = str(ser.readline().decode("utf-8"))
        myC = myDb.cursor()
        myC.execute("SELECT numPoints FROM user_info WHERE uID=%s", (deco,))
        res = myC.fetchall()
        for r in res:
            point = str(int(r[0]) + 1)
        if res:
            GPIO.output(11, False)
            GPIO.output(4, False)
            GPIO.output(18, False)
            time.sleep(1)
            GPIO.output(11, True)
            while(True):
                ret, frame = cap.read()
                gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
                bottles = bottle_cascade.detectMultiScale(gray, 1.3, 5)
                for (x, y, w, h) in bottles:
                    cv2.rectangle(frame, (x, y), (x+w, y+h), (255, 0, 0), 2)
                    for i in bottles:

                        myCur = myDb.cursor()
                        try:
                            myCur.execute("UPDATE user_info SET numPoints='" + point + "' WHERE uID=%s", (deco,))
                            myDb.commit()
                            GPIO.output(11, False)
                            GPIO.output(18, True)
                        except:
                            print("Error adding to database!")
                        myDb.close

                new = ser.inWaiting()
                if new != 0:
                    print(new)
                    print(deco)
                    break
        else:
            GPIO.output(18, False)
            GPIO.output(11, False)
            GPIO.output(4, True)


