# chapters/nebenlaufigkeit/src/thread_erzeugung.py
# Beispiel zur Threaderzeugung

import threading


def task():
    # Nebenl�ufig ausgef�hrte Aufgabe


thread = threading.Thread(target=task)
thread.start()


class MyThread(threading.Thread):
    def run(self):
        # Nebenl�ufig ausgef�hrte Aufgabe


thread = MyThread()
thread.start()
