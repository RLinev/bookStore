const PROXY_CONFIG = [
  {
    context: [
      "/books",
    ],
    target: "https://localhost:7019",
    secure: false
  },
  {
    context: [
      "/identity",
    ],
    target: "https://localhost:7019",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
