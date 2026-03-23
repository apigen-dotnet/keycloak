using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Keycloak.Admin.Models;

#nullable enable

namespace Apigen.Keycloak.Admin.Client;

/// <summary>
/// Interface for Client Attribute Certificate operations
/// </summary>
public interface IClientAttributeCertificateClient
{
  /// <summary>
  /// Get key info
  /// Operation: GET /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}
  /// </summary>
  Task<CertificateRepresentation> GetAsync(string realm, string clientUuid, string attr);

  /// <summary>
  /// Get a keystore file for the client, containing private key and public certificate
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/download
  /// </summary>
  Task<Stream> PostClientAttributeCertificateAsync(string realm, string clientUuid, string attr, Apigen.Keycloak.Admin.Models.KeyStoreConfig keyStoreConfig);

  /// <summary>
  /// Generate a new certificate with new key pair
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate
  /// </summary>
  Task<CertificateRepresentation> PostClientAttributeCertificateAsync(string realm, string clientUuid, string attr);

  /// <summary>
  /// Generate a new keypair and certificate, and get the private key file
  /// 
  /// Generates a keypair and certificate and serves the private key in a specified keystore format.
  /// Only generated public certificate is saved in Keycloak DB - the private key is not.
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/generate-and-download
  /// </summary>
  Task<Stream> PostAdminRealmsClientsCertificatesGenerateAndDownloadAsync(string realm, string clientUuid, string attr, Apigen.Keycloak.Admin.Models.KeyStoreConfig keyStoreConfig);

  /// <summary>
  /// Upload certificate and eventually private key
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload
  /// </summary>
  Task<CertificateRepresentation> PostAdminRealmsClientsCertificatesUploadAsync(string realm, string clientUuid, string attr);

  /// <summary>
  /// Upload only certificate, not private key
  /// Operation: POST /admin/realms/{realm}/clients/{client-uuid}/certificates/{attr}/upload-certificate
  /// </summary>
  Task<CertificateRepresentation> PostAdminRealmsClientsCertificatesUploadCertificateAsync(string realm, string clientUuid, string attr);

  /// <summary>
  /// Uploads a certificate, prepares the jwks or public key associated, and returns the certificate representation.
  /// Operation: POST /admin/realms/{realm}/identity-provider/upload-certificate
  /// </summary>
  Task<CertificateRepresentation> PostClientAttributeCertificateAsync(string realm);

}
