// Smooth scrolling for anchor links
document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
  anchor.addEventListener("click", function (e) {
    // Close mobile menu if open after clicking a link
    const mainNav = document.querySelector(".main-nav")
    const menuToggle = document.querySelector(".menu-toggle")
    const body = document.body

    if (mainNav.classList.contains("active")) {
      mainNav.classList.remove("active")
      menuToggle.classList.remove("active")
      body.classList.remove("menu-open") // Remove body class for overlay
    }
  })
})

// "See More" functionality for project cards
document.querySelectorAll(".see-more-button").forEach((button) => {
  button.addEventListener("click", function () {
    const category = this.dataset.category
    const projectGrid = document.querySelector(`#${category}-section .project-cards-grid`)
    const hiddenCards = projectGrid.querySelectorAll(".project-card.hidden")

    if (hiddenCards.length > 0) {
      hiddenCards.forEach((card) => {
        card.classList.remove("hidden")
      })
      this.style.display = "none" // Hide the button after showing all
    }
  })
})

// Mobile Menu Toggle and Header Scroll Behavior
document.addEventListener("DOMContentLoaded", () => {
  const menuToggle = document.querySelector(".menu-toggle")
  const mainNav = document.querySelector(".main-nav")
  const body = document.body
  const siteHeader = document.querySelector(".site-header")

  if (menuToggle && mainNav) {
    menuToggle.addEventListener("click", () => {
      mainNav.classList.toggle("active")
      menuToggle.classList.toggle("active") // For animating hamburger icon
      body.classList.toggle("menu-open") // Toggle body class for overlay
    })
  }

  // Hide/Show Header on Scroll
  let lastScrollY = window.scrollY // Initialize with current scroll position
  // Use siteHeader.offsetHeight for the actual rendered height of the header
  const headerThreshold = siteHeader.offsetHeight

  window.addEventListener("scroll", () => {
    const currentScrollY = window.scrollY

    // Only hide/show if the mobile menu is NOT open
    if (!body.classList.contains("menu-open")) {
      if (currentScrollY > lastScrollY && currentScrollY > headerThreshold) {
        // Scrolling down and past header threshold
        siteHeader.classList.add("hidden-header")
      } else if (currentScrollY < lastScrollY || currentScrollY <= headerThreshold) {
        // Scrolling up or at the very top
        siteHeader.classList.remove("hidden-header")
      }
    }
    lastScrollY = currentScrollY
  })
})
