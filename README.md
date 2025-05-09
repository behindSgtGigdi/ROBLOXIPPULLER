# GigdiPullers - Roblox IP Puller

<div align="center">
    <img src="https://i.imgur.com/tNcnAJZ.png" alt="GigdiPullers Logo" width="200">
    <br>
    <strong>Server Status:</strong>
    <br>
    <a href="https://uptime.betterstack.com/?utm_source=status_badge">
        <img src="https://uptime.betterstack.com/status-badges/v1/monitor/1p3c7.svg" alt="Server Status Badge">
    </a>
</div>

## 🌐 Overview

**GigdiPullers** is a professional IP retrieval tool specifically designed for Roblox users. Our advanced system allows you to efficiently obtain IP information from any Roblox user, providing valuable data for network analysis and research purposes.

## ✨ Features

- **Seamless IP Retrieval**: Pull IPs from Roblox users with just a few clicks
- **Secure Authentication**: User-based access control with license verification
- **Real-time Results**: Instant IP data retrieval with timestamp information
- **Professional API**: Robust backend system for reliable performance
- **User Dashboard**: Intuitive interface for managing your account and licenses

## 🚀 Getting Started

Currently, GigdiPullers is available exclusively through our web platform. Our standalone application is in development and will be released in the near future.

### Access Options:

- **Web Platform**: [GigdiPullers - Roblox IP Tool](https://vrchatapi.onrender.com/robloxpuller)
- **Community**: [Join Our Discord](https://discord.gg/7cyrKZcj8W)

## 💻 API Implementation

GigdiPullers uses a secure, authenticated API system to process requests. Our backend validates user licenses and permissions before processing IP retrieval requests:
Below is a client-side example showing how to call the Roblox IP Puller endpoint and handle all possible responses. This demonstrates the required headers, query parameter, and how to interpret the status codes and error messages.

```javascript
// Example of our API implementation
/**
 * lookupRobloxIp.js
 * Client-side utility for calling the GigdiPullers Roblox IP Puller API.
 */

import fetch from 'node-fetch'; // or axios, or browser fetch

/**
 * Calls the `/roblox/api/v1/lookup-ip` endpoint.
 * 
 * @param {string} displayName  – The Roblox display name to look up (required).
 * @param {string} jwtToken     – Your JWT from logging in (required for authentication).
 * @returns {Promise<object>}    – An object with { status, data } where data is the parsed JSON.
 */
export async function lookupRobloxIp(displayName, jwtToken) {
  const url = new URL('https://vrchatapi.onrender.com/roblox/api/v1/lookup-ip');
  url.searchParams.set('displayName', displayName);

  const response = await fetch(url.toString(), {
    method: 'GET',
    headers: {
      'Authorization': `Bearer ${jwtToken}`,   // 📌 must include a valid JWT
      'Cache-Control': 'no-cache'             // sensitive data should not be cached
    }
  });

  const data = await response.json();
  return { status: response.status, data };
}

// Example usage:
(async () => {
  const jwtToken   = 'YOUR_JWT_TOKEN_HERE';
  const targetUser = 'BuilderBob123';

  try {
    const { status, data } = await lookupRobloxIp(targetUser, jwtToken);

    if (status === 200 && data.success) {
      console.log(`✅ ${data.displayName} → IP ${data.ipAddress} at ${data.timestamp}`);
      // handle successful IP retrieval
    }
    else if (status === 200 && !data.success) {
      console.warn(`⚠️ No data: ${data.message}`);
      // message: "No IP data found for this display name."
    }
    else if (status === 400) {
      console.error(`❌ Bad Request: ${data.message}`);
      // message: "Display Name is required."
    }
    else if (status === 403) {
      console.error(`❌ Access Denied: ${data.message}`);
      // messages include:
      // "Access denied. Please purchase this feature to proceed."
      // "Access denied. Your license has expired. Please purchase a new one."
    }
    else if (status === 500) {
      console.error(`❌ Server Error: ${data.message}`);
      // messages include:
      // "Failed to connect to Roblox database."
      // "Error retrieving IP data."
      // "An unexpected error occurred."
    }
    else {
      console.error(`❌ Unexpected status ${status}`, data);
    }
  }
  catch (err) {
    console.error('Network or parsing error:', err);
  }
})();
```

## 📜 License System

GigdiPullers operates on a license-based system:

- Licenses have specific durations
- System automatically validates license status
- Expired licenses are removed from user accounts
- Purchase verification before feature access

## ⚠️ Legal Disclaimer

GigdiPullers is intended for legitimate network analysis, educational purposes, and authorized research only. Users must comply with all applicable laws and Roblox's Terms of Service. Misuse of this tool may result in account termination and potential legal consequences.

**By using GigdiPullers, you agree to:**
- Only use the tool for lawful purposes
- Not use retrieved information to harm, harass, or exploit others
- Take full responsibility for your usage of the tool

## 📞 Support

Need assistance or have questions? Join our Discord community for immediate support and updates on new features:

- **Discord**: [GigdiPullers Community](https://discord.gg/7cyrKZcj8W)
- **GitHub**: [GigdiPullers Repository](https://github.com/behindSgtGigdi/ROBLOXIPPULLER/tree/main)

---

<div align="center">
    © 2025 GigdiPullers | All Rights Reserved
</div>