import os
import socket
import win32net
import ipaddress

def get_admin_shares(ip_address):
    """Sucht nach administrativen Freigaben auf einem bestimmten Computer"""
    try:
        shares = win32net.NetShareEnum(ip_address)
        admin_shares = [share for share in shares[0] if share['type'] == 0x80000000]
        return admin_shares
    except Exception as e:
        print(f"Fehler beim Abrufen der Freigaben von {ip_address}: {e}")
        return []

def document_admin_shares(output_file):
    """Dokumentiert die administrativen Freigaben in einer Textdatei"""
    with open(output_file, "w") as f:
        f.write("Gefundene administrative Freigaben:\n\n")
        for ip_address in get_all_ip_addresses():
            admin_shares = get_admin_shares(ip_address)
            if admin_shares:
                f.write(f"IP-Adresse: {ip_address}\n")
                for share in admin_shares:
                    f.write(f"- {share['netname']}\n")
                f.write("\n")

def get_all_ip_addresses():
    """Ruft eine Liste aller IP-Adressen im lokalen Netzwerk ab"""
    try:
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        s.connect(("8.8.8.8", 80))
        local_ip = s.getsockname()[0].split(".")[:-1]
        local_network = f"{'.'.join(local_ip)}.0/24"
        return [str(ip) for ip in ipaddress.IPv4Network(local_network)]
    except Exception as e:
        print(f"Fehler beim Abrufen der IP-Adressen: {e}")
        return []

if __name__ == "__main__":
    output_file = "admin_shares.txt"
    document_admin_shares(output_file)
    print(f"Ergebnisse wurden in {output_file} gespeichert.")
